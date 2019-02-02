namespace NetTest
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
            this.txt_Gateway = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Times = new System.Windows.Forms.TextBox();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.pgb_Test = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txt_Gateway
            // 
            this.txt_Gateway.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Gateway.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Gateway.Location = new System.Drawing.Point(95, 12);
            this.txt_Gateway.Name = "txt_Gateway";
            this.txt_Gateway.Size = new System.Drawing.Size(617, 21);
            this.txt_Gateway.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "网关地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 99;
            this.label2.Text = "循环次数：";
            // 
            // txt_Times
            // 
            this.txt_Times.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Times.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Times.Location = new System.Drawing.Point(95, 45);
            this.txt_Times.Name = "txt_Times";
            this.txt_Times.Size = new System.Drawing.Size(74, 21);
            this.txt_Times.TabIndex = 3;
            this.txt_Times.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Result
            // 
            this.txt_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Result.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Result.Location = new System.Drawing.Point(12, 72);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ReadOnly = true;
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Result.Size = new System.Drawing.Size(698, 279);
            this.txt_Result.TabIndex = 99;
            this.txt_Result.TabStop = false;
            // 
            // btn_Begin
            // 
            this.btn_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Begin.Location = new System.Drawing.Point(175, 45);
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
            this.btn_Clean.Location = new System.Drawing.Point(265, 45);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(84, 21);
            this.btn_Clean.TabIndex = 1;
            this.btn_Clean.Text = "清空(Esc)";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // pgb_Test
            // 
            this.pgb_Test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgb_Test.Location = new System.Drawing.Point(12, 357);
            this.pgb_Test.Name = "pgb_Test";
            this.pgb_Test.Size = new System.Drawing.Size(700, 23);
            this.pgb_Test.Step = 1;
            this.pgb_Test.TabIndex = 99;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_Begin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Clean;
            this.ClientSize = new System.Drawing.Size(724, 392);
            this.Controls.Add(this.pgb_Test);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.btn_Begin);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.txt_Times);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Gateway);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(740, 38);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超赢支付网关网络测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Gateway;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Times;
        private System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.Button btn_Begin;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.ProgressBar pgb_Test;
    }
}

