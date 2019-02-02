using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NetTest.Extension;
using NetTest.HttpClientUtils;

namespace NetTest
{
    public partial class MainForm : Form
    {
        private SynchronizationContext SyncContext = null;
        private List<Button> arr_btn = new List<Button>();

        public MainForm()
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;

            this.txt_Gateway.Text = ObjectExtensions.ValueOrEmpty(ConfigurationManager.AppSettings["Gateway"], "https://pay.storepos.cn/UnifiedPay/Gateway").Trim();
            this.txt_Times.Text = ObjectExtensions.ValueOrEmpty(ConfigurationManager.AppSettings["Times"], "10").Trim();

            arr_btn.Add(this.btn_Begin);
            arr_btn.Add(this.btn_Clean);
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            this.EnableControl(false);

            #region 参数校验

            var list_err = new List<string>();
            if (!ObjectExtensions.IsURL(this.txt_Gateway.Text))
                list_err.Add("网关地址错误");

            if (!ObjectExtensions.IsInt(this.txt_Times.Text))
                list_err.Add("循环次数错误");
            else if (StringExtension.ToInt32(this.txt_Times.Text) <= 0)
                list_err.Add("循环次数大于零");
            else if (StringExtension.ToInt32(this.txt_Times.Text) > int.MaxValue)
                list_err.Add("循环次数超出允许上限");

            if (list_err.Count > 0)
            {
                this.AppendResult(StringExtension.Join(list_err.ToArray(), ";"));
                this.EnableControl(true);
                return;
            }

            #endregion 参数校验

            this.pgb_Test.Maximum = StringExtension.ToInt32(this.txt_Times.Text);
            this.pgb_Test.Value = 0;
            new Thread(new ThreadStart(RunTest)) { IsBackground = true }.Start();
        }

        private void RunTest()
        {
            try
            {
                #region 开始测试

                var first_Duration = 0;                 // 首次耗时
                var max_Duration = 0;                   // 最大耗时
                var min_Duration = 0;                   // 最小耗时
                var Times = StringExtension.ToInt32(this.txt_Times.Text) + 1;
                var Url = this.txt_Gateway.Text.Trim();
                var content = new StringBuilder();
                content.Append("&agent_id=13000000000000000");
                content.Append("&method=OrderQuery");
                content.Append("&mch_id=1427848602");
                content.Append("&version=1.0");
                content.Append("&pid=yzq_product");
                content.Append("&paytype=WECHAT");
                content.Append("&out_trade_no=T0000001548647000000");
                content.Append("&sign=23b1c670f3679bfb6baa879d02d09bbf");

                var _clientContext = new ClientContext(new ClassicClient());

                SyncContext.Send(this.AppendResult, "测试开始");
                var dt_begin_Global = DateTime.Now;

                #region 循环POST

                for (int i = 1; i < Times; i++)
                {
                    var dt_begin = DateTime.Now;
                    var str_response_json = default(string);
                    try
                    {
                        str_response_json = _clientContext.Post(Url, content.ToString().TrimStart('&'));
                    }
                    catch (Exception ex)
                    {
                        SyncContext.Send(this.AppendResult, "【Error】" + ex);
                    }
                    var dt_end = DateTime.Now;

                    var curr_Duration = (int)(dt_end - dt_begin).TotalMilliseconds;
                    if (1 == i)
                    {
                        first_Duration = curr_Duration;
                        min_Duration = curr_Duration;
                    }

                    if (curr_Duration > max_Duration)
                        max_Duration = curr_Duration;

                    if (curr_Duration < min_Duration)
                        min_Duration = curr_Duration;

                    SyncContext.Send(this.UpdateProgress, 1);
                    SyncContext.Send(this.AppendResult, string.Format("第【{0}】次请求，【耗时】{1}ms，【响应报文】：\r\n{2}", i, curr_Duration, ObjectExtensions.ValueOrEmpty(str_response_json)));
                }

                #endregion 循环POST

                var dt_end_Global = DateTime.Now;

                #region 统计

                var total = (int)(dt_end_Global - dt_begin_Global).TotalMilliseconds;
                var avg = (int)(total / (Times - 1));

                #endregion 统计

                SyncContext.Send(this.AppendResult, string.Format("测试完成，【合计耗时】：{0}ms，【首次耗时】：{1}ms，【最大耗时】：{2}ms，【最小耗时】：{3}ms，【平均耗时】：{4}ms", total, first_Duration, max_Duration, min_Duration, avg));
                MessageBox.Show(text: string.Format("【合计耗时】：{0}ms\r\n【首次耗时】：{1}ms\r\n【最大耗时】：{2}ms\r\n【最小耗时】：{3}ms\r\n【平均耗时】：{4}ms", total, first_Duration, max_Duration, min_Duration, avg)
                    , caption: "测试完成"
                    , buttons: MessageBoxButtons.OK
                    , icon: MessageBoxIcon.Information);

                #endregion 开始测试
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

        private void AppendResult(object result)
        {
            if (ObjectExtensions.IsNullOrWhiteSpace(result))
                return;

            this.txt_Result.AppendText(ObjectExtensions.ValueOrEmpty(result));
            this.txt_Result.AppendText("\r\n");
            this.txt_Result.AppendText("----------------------------------------------------------------------------------------------------------------");
            this.txt_Result.AppendText("\r\n");
            this.txt_Result.AppendText("\r\n");
        }

        private void EnableControl(object isEnabled)
        {
            var _isEnabled = Convert.ToBoolean(isEnabled);
            arr_btn.ForEach(item => item.Enabled = _isEnabled);

            this.txt_Gateway.ReadOnly = !_isEnabled;
            this.txt_Times.ReadOnly = !_isEnabled;
        }

        private void UpdateProgress(object step)
        {
            var _step = Convert.ToInt32(step);
            if ((this.pgb_Test.Value + _step) <= this.pgb_Test.Maximum)
                this.pgb_Test.Value += _step;
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            this.txt_Result.Clear();
        }
    }
}
