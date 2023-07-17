namespace FormManager
{
    partial class AddStationTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStationTotal));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExcelFilePath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBoxTopu = new System.Windows.Forms.CheckBox();
            this.checkBoxPNIO = new System.Windows.Forms.CheckBox();
            this.checkBoxSubnet = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddConfirm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExcelFilePath);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.checkBoxTopu);
            this.groupBox2.Controls.Add(this.checkBoxPNIO);
            this.groupBox2.Controls.Add(this.checkBoxSubnet);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.AddConfirm);
            this.groupBox2.Location = new System.Drawing.Point(37, 38);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(463, 278);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CPU主站，分布式站点";
            // 
            // ExcelFilePath
            // 
            this.ExcelFilePath.Location = new System.Drawing.Point(28, 70);
            this.ExcelFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.ExcelFilePath.Name = "ExcelFilePath";
            this.ExcelFilePath.Size = new System.Drawing.Size(413, 25);
            this.ExcelFilePath.TabIndex = 20;
            this.ExcelFilePath.Text = "D:\\OpennessTestFuntion\\Data\\TotalStation.xlsx";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 235);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(414, 22);
            this.progressBar1.TabIndex = 14;
            // 
            // checkBoxTopu
            // 
            this.checkBoxTopu.AutoSize = true;
            this.checkBoxTopu.Location = new System.Drawing.Point(253, 129);
            this.checkBoxTopu.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTopu.Name = "checkBoxTopu";
            this.checkBoxTopu.Size = new System.Drawing.Size(89, 19);
            this.checkBoxTopu.TabIndex = 13;
            this.checkBoxTopu.Text = "拓扑连接";
            this.checkBoxTopu.UseVisualStyleBackColor = true;
            // 
            // checkBoxPNIO
            // 
            this.checkBoxPNIO.AutoSize = true;
            this.checkBoxPNIO.Location = new System.Drawing.Point(129, 129);
            this.checkBoxPNIO.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPNIO.Name = "checkBoxPNIO";
            this.checkBoxPNIO.Size = new System.Drawing.Size(91, 19);
            this.checkBoxPNIO.TabIndex = 12;
            this.checkBoxPNIO.Text = "PNIO系统";
            this.checkBoxPNIO.UseVisualStyleBackColor = true;
            // 
            // checkBoxSubnet
            // 
            this.checkBoxSubnet.AutoSize = true;
            this.checkBoxSubnet.Location = new System.Drawing.Point(28, 129);
            this.checkBoxSubnet.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSubnet.Name = "checkBoxSubnet";
            this.checkBoxSubnet.Size = new System.Drawing.Size(59, 19);
            this.checkBoxSubnet.TabIndex = 11;
            this.checkBoxSubnet.Text = "子网";
            this.checkBoxSubnet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "使用Excel表格添加模块";
            // 
            // AddConfirm
            // 
            this.AddConfirm.Location = new System.Drawing.Point(27, 179);
            this.AddConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.AddConfirm.Name = "AddConfirm";
            this.AddConfirm.Size = new System.Drawing.Size(100, 29);
            this.AddConfirm.TabIndex = 0;
            this.AddConfirm.Text = "确认添加";
            this.AddConfirm.UseVisualStyleBackColor = true;
            this.AddConfirm.Click += new System.EventHandler(this.AddConfirm_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 322);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(463, 324);
            this.textBox1.TabIndex = 11;
            this.textBox1.WordWrap = false;
            // 
            // AddStationTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 661);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddStationTotal";
            this.Text = "添加站点";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxTopu;
        private System.Windows.Forms.CheckBox checkBoxPNIO;
        private System.Windows.Forms.CheckBox checkBoxSubnet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddConfirm;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox ExcelFilePath;
    }
}