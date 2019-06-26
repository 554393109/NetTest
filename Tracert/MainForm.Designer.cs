namespace Tracert
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txt_DomainOrIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_DomainOrIP
            // 
            this.txt_DomainOrIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DomainOrIP.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DomainOrIP.Location = new System.Drawing.Point(95, 12);
            this.txt_DomainOrIP.Name = "txt_DomainOrIP";
            this.txt_DomainOrIP.Size = new System.Drawing.Size(295, 21);
            this.txt_DomainOrIP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "域名/IP：";
            // 
            // txt_Result
            // 
            this.txt_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Result.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_Result.ForeColor = System.Drawing.Color.Silver;
            this.txt_Result.Location = new System.Drawing.Point(12, 39);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ReadOnly = true;
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Result.Size = new System.Drawing.Size(558, 511);
            this.txt_Result.TabIndex = 99;
            this.txt_Result.TabStop = false;
            // 
            // btn_Begin
            // 
            this.btn_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Begin.Location = new System.Drawing.Point(396, 11);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(84, 21);
            this.btn_Begin.TabIndex = 0;
            this.btn_Begin.Text = "开始(&Enter)";
            this.btn_Begin.UseVisualStyleBackColor = true;
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clean.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Clean.Location = new System.Drawing.Point(486, 11);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(84, 21);
            this.btn_Clean.TabIndex = 1;
            this.btn_Clean.Text = "清空(Esc)";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_Begin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Clean;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.btn_Begin);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.txt_DomainOrIP);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppTitle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_DomainOrIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.Button btn_Begin;
        private System.Windows.Forms.Button btn_Clean;
    }
}

