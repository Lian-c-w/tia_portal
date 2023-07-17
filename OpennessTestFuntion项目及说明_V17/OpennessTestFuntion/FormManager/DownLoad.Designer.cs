namespace FormManager
{
    partial class DownLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownLoad));
            this.button1 = new System.Windows.Forms.Button();
            this.下载选项 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.选择网卡 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.目标IP地址 = new System.Windows.Forms.TextBox();
            this.接口 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 下载选项
            // 
            this.下载选项.FormattingEnabled = true;
            this.下载选项.Items.AddRange(new object[] {
            "硬件完全",
            "软件完全",
            "硬件仅更改、软件完全",
            "软件仅更改",
            "硬件仅更改、软件仅更改"});
            this.下载选项.Location = new System.Drawing.Point(119, 158);
            this.下载选项.Name = "下载选项";
            this.下载选项.Size = new System.Drawing.Size(260, 23);
            this.下载选项.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "下载选项";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 236);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(475, 75);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // 选择网卡
            // 
            this.选择网卡.FormattingEnabled = true;
            this.选择网卡.Location = new System.Drawing.Point(119, 66);
            this.选择网卡.Name = "选择网卡";
            this.选择网卡.Size = new System.Drawing.Size(259, 23);
            this.选择网卡.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "选择网卡";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "目标IP地址";
            // 
            // 目标IP地址
            // 
            this.目标IP地址.Location = new System.Drawing.Point(119, 22);
            this.目标IP地址.Name = "目标IP地址";
            this.目标IP地址.Size = new System.Drawing.Size(259, 25);
            this.目标IP地址.TabIndex = 8;
            this.目标IP地址.Text = "192.168.100.80";
            // 
            // 接口
            // 
            this.接口.FormattingEnabled = true;
            this.接口.Location = new System.Drawing.Point(119, 112);
            this.接口.Name = "接口";
            this.接口.Size = new System.Drawing.Size(260, 23);
            this.接口.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "选择接口";
            // 
            // DownLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 331);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.接口);
            this.Controls.Add(this.目标IP地址);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.选择网卡);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.下载选项);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownLoad";
            this.Text = "下载";
            this.Shown += new System.EventHandler(this.DownLoad_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox 下载选项;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox 选择网卡;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox 目标IP地址;
        private System.Windows.Forms.ComboBox 接口;
        private System.Windows.Forms.Label label4;
    }
}