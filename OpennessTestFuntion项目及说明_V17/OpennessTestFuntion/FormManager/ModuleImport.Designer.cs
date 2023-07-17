namespace FormManager
{
    partial class ModuleImport
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
            this.ModuleSelect = new System.Windows.Forms.ListBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.选择生成内容 = new System.Windows.Forms.Label();
            this.labelCPUName = new System.Windows.Forms.Label();
            this.textBoxCPUName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLibrary = new System.Windows.Forms.TextBox();
            this.LibraryUpdate = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ModuleSelect
            // 
            this.ModuleSelect.FormattingEnabled = true;
            this.ModuleSelect.ItemHeight = 12;
            this.ModuleSelect.Location = new System.Drawing.Point(26, 138);
            this.ModuleSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModuleSelect.Name = "ModuleSelect";
            this.ModuleSelect.Size = new System.Drawing.Size(371, 52);
            this.ModuleSelect.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(100, 233);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(56, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // 选择生成内容
            // 
            this.选择生成内容.AutoSize = true;
            this.选择生成内容.Location = new System.Drawing.Point(26, 120);
            this.选择生成内容.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.选择生成内容.Name = "选择生成内容";
            this.选择生成内容.Size = new System.Drawing.Size(77, 12);
            this.选择生成内容.TabIndex = 2;
            this.选择生成内容.Text = "选择生成内容";
            // 
            // labelCPUName
            // 
            this.labelCPUName.AutoSize = true;
            this.labelCPUName.Location = new System.Drawing.Point(26, 15);
            this.labelCPUName.Name = "labelCPUName";
            this.labelCPUName.Size = new System.Drawing.Size(71, 12);
            this.labelCPUName.TabIndex = 10;
            this.labelCPUName.Text = "CPU站点名称";
            // 
            // textBoxCPUName
            // 
            this.textBoxCPUName.Location = new System.Drawing.Point(100, 15);
            this.textBoxCPUName.Name = "textBoxCPUName";
            this.textBoxCPUName.Size = new System.Drawing.Size(297, 21);
            this.textBoxCPUName.TabIndex = 9;
            this.textBoxCPUName.Text = "stationCPU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "XML文件路径";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(100, 46);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(297, 21);
            this.textBoxPath.TabIndex = 11;
            this.textBoxPath.Text = "E:\\OpennessUsageV15\\Data\\Import\\XML文件\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "库路径";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxLibrary
            // 
            this.textBoxLibrary.Location = new System.Drawing.Point(100, 82);
            this.textBoxLibrary.Name = "textBoxLibrary";
            this.textBoxLibrary.Size = new System.Drawing.Size(297, 21);
            this.textBoxLibrary.TabIndex = 13;
            this.textBoxLibrary.Text = "E:\\OpennessUsageV15\\Data\\Import\\库2\\库2.al15";
            // 
            // LibraryUpdate
            // 
            this.LibraryUpdate.Location = new System.Drawing.Point(174, 233);
            this.LibraryUpdate.Name = "LibraryUpdate";
            this.LibraryUpdate.Size = new System.Drawing.Size(61, 23);
            this.LibraryUpdate.TabIndex = 15;
            this.LibraryUpdate.Text = "库更新";
            this.LibraryUpdate.UseVisualStyleBackColor = true;
            this.LibraryUpdate.Click += new System.EventHandler(this.LibraryUpdate_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(26, 233);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(56, 23);
            this.buttonRefresh.TabIndex = 16;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 202);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(371, 18);
            this.progressBar1.TabIndex = 17;
            // 
            // ModuleImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 281);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.LibraryUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLibrary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelCPUName);
            this.Controls.Add(this.textBoxCPUName);
            this.Controls.Add(this.选择生成内容);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.ModuleSelect);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ModuleImport";
            this.Text = "ModuleImport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModuleImport_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ModuleSelect;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label 选择生成内容;
        private System.Windows.Forms.Label labelCPUName;
        private System.Windows.Forms.TextBox textBoxCPUName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLibrary;
        private System.Windows.Forms.Button LibraryUpdate;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}