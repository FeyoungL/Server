namespace Sever
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
            this.Rtb_Msg = new System.Windows.Forms.RichTextBox();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Cb_ClientAddr = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Rtb_Msg
            // 
            this.Rtb_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rtb_Msg.Location = new System.Drawing.Point(13, 153);
            this.Rtb_Msg.Name = "Rtb_Msg";
            this.Rtb_Msg.Size = new System.Drawing.Size(316, 139);
            this.Rtb_Msg.TabIndex = 0;
            this.Rtb_Msg.Text = "";
            this.Rtb_Msg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Rtb_Msg_KeyUp);
            // 
            // Btn_Create
            // 
            this.Btn_Create.Location = new System.Drawing.Point(13, 298);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(75, 23);
            this.Btn_Create.TabIndex = 1;
            this.Btn_Create.Text = "创建服务器";
            this.Btn_Create.UseVisualStyleBackColor = true;
            this.Btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // Btn_Close
            // 
            this.Btn_Close.Location = new System.Drawing.Point(150, 298);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(75, 23);
            this.Btn_Close.TabIndex = 2;
            this.Btn_Close.Text = "关闭服务器";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Cb_ClientAddr
            // 
            this.Cb_ClientAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_ClientAddr.FormattingEnabled = true;
            this.Cb_ClientAddr.Location = new System.Drawing.Point(13, 13);
            this.Cb_ClientAddr.Name = "Cb_ClientAddr";
            this.Cb_ClientAddr.Size = new System.Drawing.Size(163, 20);
            this.Cb_ClientAddr.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 411);
            this.Controls.Add(this.Cb_ClientAddr);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Btn_Create);
            this.Controls.Add(this.Rtb_Msg);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Disposed += new System.EventHandler(this.Form_Disposed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Rtb_Msg;
        private System.Windows.Forms.Button Btn_Create;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.ComboBox Cb_ClientAddr;
    }
}

