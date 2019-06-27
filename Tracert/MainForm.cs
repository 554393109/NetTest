using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Tracert.Extension;
using Tracert.Model;

namespace Tracert
{
    public partial class MainForm : Form
    {
        private SynchronizationContext SyncContext = null;
        private static readonly object locker = new object();
        private List<Button> arr_btn = new List<Button>();

        private static byte[] PING_BUFFER = new byte[] { 0 };
        private static bool isFinish = false;              // 到达目标地址
        private static Thread thread;
        private static List<string> list_log = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;

            this.Text = Setting.AppTitle;
            this.txt_DomainOrIP.Text = Setting.Domain;

            arr_btn.Add(this.btn_Begin);
            arr_btn.Add(this.btn_Clean);
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            this.EnableControl(false);
            list_log.Clear();

            #region 参数校验

            var list_err = new List<string>();
            var domain = this.txt_DomainOrIP.Text.Trim();
            var icmp_param = new ICMP_PARAM { PingOptions = new PingOptions(1, false) };
            if (IPAddress.TryParse(domain, out icmp_param.IPAddress))
            {
                SyncContext.Send(this.AppendResult,
                    string.Format("正在跟踪到 {0} 间的路由：", icmp_param.IPAddress.ToString()));
            }
            else
            {
                // 解析域名
                var regEx = new Regex("\\d+\\.\\d+\\.\\d+\\.\\d+");     // 最多4级域名
                var hostEntry = default(IPHostEntry);

                try
                {
                    hostEntry = Dns.GetHostEntry(this.txt_DomainOrIP.Text);
                    foreach (var ipAddr in hostEntry.AddressList)
                    {
                        if (regEx.IsMatch(ipAddr.ToString()))
                        {
                            icmp_param.IPAddress = ipAddr;
                            break;
                        }
                    }

                    if (icmp_param.IPAddress == null)
                        list_err.Add("域名错误或无法解析");
                    else
                    {
                        SyncContext.Send(this.AppendResult,
                            string.Format("正在跟踪到 {0} [{1}] 间的路由：", domain, icmp_param.IPAddress.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    list_err.Add(ex.Message);
                }
            }

            if (list_err.Count > 0)
            {
                this.AppendResult(StringExtension.Join(list_err.ToArray(), ";"));
                WriteLogFile();
                this.EnableControl(true);
                return;
            }

            #endregion 参数校验

            thread = new Thread(new ParameterizedThreadStart(Icmp_Ping)) { IsBackground = true };
            thread.Start(icmp_param);
        }

        public void Icmp_Ping(object _icmp_param)
        {
            try
            {
                var icmp_param = (ICMP_PARAM)_icmp_param;

                var icmp = new Ping();
                icmp.PingCompleted += Icmp_PingCompleted;

                var dt_begin = DateTime.Now;
                icmp_param.SendTicks = dt_begin.Ticks;
                icmp.SendAsync(icmp_param.IPAddress, Setting.Timemout, PING_BUFFER, icmp_param.PingOptions, icmp_param);

                while (!isFinish)
                {
                    Thread.Sleep(millisecondsTimeout: 1);
                }
            }
            catch (Exception ex)
            {
                SyncContext.Send(this.AppendResult, "【Exception】" + ex);
            }
            finally
            {
                SyncContext.Send(this.EnableControl, true);
            }
        }

        private void Icmp_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            var dt_finish = DateTime.Now;
            var icmp_param = (ICMP_PARAM)e.UserState;
            long nDeltaMS = (dt_finish.Ticks - icmp_param.SendTicks) / TimeSpan.TicksPerMillisecond;

            SyncContext.Send(this.AppendResult,
                string.Format("【跃点数】：{0}\t\t【耗时】：{1}\t\t【主机地址】：{2}",
                    icmp_param.PingOptions.Ttl,
                    (e.Reply.Status == IPStatus.TimedOut) ? "*" : nDeltaMS.ToString() + "ms",
                    e.Reply.Address.ToString()));

            if (icmp_param.IPAddress.Equals(e.Reply.Address))
            {
                SyncContext.Send(this.AppendResult, "已到达目标地址！");
                isFinish = true;
                WriteLogFile();
                return;
            }

            if (icmp_param.PingOptions.Ttl >= Setting.MaxHops)
            {
                SyncContext.Send(this.AppendResult, "已达到最大跃点数！");
                isFinish = true;
                WriteLogFile();
                return;
            }

            var icmp = (Ping)sender;
            icmp_param.PingOptions.Ttl++;
            icmp_param.SendTicks = DateTime.Now.Ticks;
            icmp.SendAsync(icmp_param.IPAddress, Setting.Timemout, PING_BUFFER, icmp_param.PingOptions, icmp_param);
        }

        private void AppendResult(object result)
        {
            if (ObjectExtensions.IsNullOrWhiteSpace(result))
                return;

            this.txt_Result.AppendText(ObjectExtensions.ValueOrEmpty(result));
            this.txt_Result.AppendText(Environment.NewLine);
            this.txt_Result.AppendText(Environment.NewLine);

            list_log.Add(ObjectExtensions.ValueOrEmpty(result));
            list_log.Add(Environment.NewLine);
        }

        private void EnableControl(object isEnabled)
        {
            var _isEnabled = Convert.ToBoolean(isEnabled);
            arr_btn.ForEach(item => item.Enabled = _isEnabled);

            this.txt_DomainOrIP.ReadOnly = !_isEnabled;
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            this.txt_Result.Clear();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }

        private void WriteLogFile()
        {
            try
            {
                if (list_log.Count > 0)
                {
                    var name_file = string.Format("Tracert-{0:yyMMddHHmmss}-【{1}】.log", DateTime.Now, this.txt_DomainOrIP.Text.Trim());
                    var path_file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name_file);

                    lock (locker)
                    {
                        var file = new FileInfo(path_file);
                        if (file.Exists
                            && file.Attributes == FileAttributes.ReadOnly)
                        {
                            MessageBox.Show(string.Format("{0} 已存在，且文件只读无法写入日志", name_file));
                            return;
                        }

                        using (var sw = new StreamWriter(path_file, append: true, encoding: Encoding.UTF8))
                        {
                            sw.Write(StringExtension.Join(list_log.ToArray(), string.Empty));
                            sw.Flush();
                            sw.Dispose();
                        }
                    }

                    SyncContext.Send(this.AppendResult,
                                string.Format("日志文件：{0}", path_file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
