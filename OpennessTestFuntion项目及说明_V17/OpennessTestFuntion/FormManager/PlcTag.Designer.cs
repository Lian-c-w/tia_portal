namespace FormManager
{
    partial class PlcTag
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxImport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxExport = new System.Windows.Forms.TextBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelCPUName = new System.Windows.Forms.Label();
            this.textBoxCPUName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "导入路径";
            // 
            // textBoxImport
            // 
            this.textBoxImport.Location = new System.Drawing.Point(99, 63);
            this.textBoxImport.Name = "textBoxImport";
            this.textBoxImport.Size = new System.Drawing.Size(302, 21);
            this.textBoxImport.TabIndex = 4;
            this.textBoxImport.Text = "E:\\OpennessUsageV15\\Data\\Import\\PLC变量\\Tag.xml";
            this.textBoxImport.TextChanged += new System.EventHandler(this.textBoxImport_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "导出路径";
            // 
            // textBoxExport
            // 
            this.textBoxExport.Location = new System.Drawing.Point(99, 99);
            this.textBoxExport.Name = "textBoxExport";
            this.textBoxExport.Size = new System.Drawing.Size(302, 21);
            this.textBoxExport.TabIndex = 6;
            this.textBoxExport.Text = "E:\\OpennessUsageV15\\Data\\Export\\PLC变量\\";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(43, 153);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "导入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(138, 153);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelCPUName
            // 
            this.labelCPUName.AutoSize = true;
            this.labelCPUName.Location = new System.Drawing.Point(25, 30);
            this.labelCPUName.Name = "labelCPUName";
            this.labelCPUName.Size = new System.Drawing.Size(71, 12);
            this.labelCPUName.TabIndex = 12;
            this.labelCPUName.Text = "CPU站点名称";
            // 
            // textBoxCPUName
            // 
            this.textBoxCPUName.Location = new System.Drawing.Point(99, 27);
            this.textBoxCPUName.Name = "textBoxCPUName";
            this.textBoxCPUName.Size = new System.Drawing.Size(302, 21);
            this.textBoxCPUName.TabIndex = 11;
            this.textBoxCPUName.Text = "stationCPU";
            // 
            // PlcTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 221);
            this.Controls.Add(this.labelCPUName);
            this.Controls.Add(this.textBoxCPUName);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxImport);
            this.Name = "PlcTag";
            this.Text = "PLC变量";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelCPUName;
        private System.Windows.Forms.TextBox textBoxCPUName;
    }
}