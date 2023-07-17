namespace FormManager
{
    partial class ImportExport
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
            this.textBoxExport = new System.Windows.Forms.TextBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonUpDate = new System.Windows.Forms.Button();
            this.labelCPUName = new System.Windows.Forms.Label();
            this.textBoxCPUName = new System.Windows.Forms.TextBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.AddFile = new System.Windows.Forms.Button();
            this.labelXMLFile = new System.Windows.Forms.Label();
            this.labelLibrary = new System.Windows.Forms.Label();
            this.AddLibrary = new System.Windows.Forms.Button();
            this.listBoxLibrary = new System.Windows.Forms.ListBox();
            this.ImportGroupFiles = new System.Windows.Forms.Button();
            this.treeViewProgram = new System.Windows.Forms.TreeView();
            this.GetSoftwareInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "导出路径";
            // 
            // textBoxExport
            // 
            this.textBoxExport.Location = new System.Drawing.Point(102, 182);
            this.textBoxExport.Name = "textBoxExport";
            this.textBoxExport.Size = new System.Drawing.Size(281, 21);
            this.textBoxExport.TabIndex = 2;
            this.textBoxExport.Text = "E:\\OpennessUsageV15_2\\Data\\Export\\XML文件\\";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(35, 227);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(57, 23);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "导入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(128, 227);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(57, 23);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonUpDate
            // 
            this.buttonUpDate.Location = new System.Drawing.Point(227, 227);
            this.buttonUpDate.Name = "buttonUpDate";
            this.buttonUpDate.Size = new System.Drawing.Size(57, 23);
            this.buttonUpDate.TabIndex = 6;
            this.buttonUpDate.Text = "库更新";
            this.buttonUpDate.UseVisualStyleBackColor = true;
            this.buttonUpDate.Click += new System.EventHandler(this.buttonUpDate_Click);
            // 
            // labelCPUName
            // 
            this.labelCPUName.AutoSize = true;
            this.labelCPUName.Location = new System.Drawing.Point(33, 22);
            this.labelCPUName.Name = "labelCPUName";
            this.labelCPUName.Size = new System.Drawing.Size(71, 12);
            this.labelCPUName.TabIndex = 8;
            this.labelCPUName.Text = "CPU站点名称";
            // 
            // textBoxCPUName
            // 
            this.textBoxCPUName.Location = new System.Drawing.Point(119, 19);
            this.textBoxCPUName.Name = "textBoxCPUName";
            this.textBoxCPUName.Size = new System.Drawing.Size(264, 21);
            this.textBoxCPUName.TabIndex = 7;
            this.textBoxCPUName.Text = "stationCPU";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 12;
            this.listBoxFiles.Location = new System.Drawing.Point(35, 446);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(255, 52);
            this.listBoxFiles.TabIndex = 9;
            // 
            // AddFile
            // 
            this.AddFile.Location = new System.Drawing.Point(119, 53);
            this.AddFile.Name = "AddFile";
            this.AddFile.Size = new System.Drawing.Size(57, 23);
            this.AddFile.TabIndex = 10;
            this.AddFile.Text = "添加";
            this.AddFile.UseVisualStyleBackColor = true;
            this.AddFile.Click += new System.EventHandler(this.AddFile_Click);
            // 
            // labelXMLFile
            // 
            this.labelXMLFile.AutoSize = true;
            this.labelXMLFile.Location = new System.Drawing.Point(33, 58);
            this.labelXMLFile.Name = "labelXMLFile";
            this.labelXMLFile.Size = new System.Drawing.Size(71, 12);
            this.labelXMLFile.TabIndex = 11;
            this.labelXMLFile.Text = "选择XML文件";
            // 
            // labelLibrary
            // 
            this.labelLibrary.AutoSize = true;
            this.labelLibrary.Location = new System.Drawing.Point(33, 99);
            this.labelLibrary.Name = "labelLibrary";
            this.labelLibrary.Size = new System.Drawing.Size(65, 12);
            this.labelLibrary.TabIndex = 14;
            this.labelLibrary.Text = "选择库文件";
            // 
            // AddLibrary
            // 
            this.AddLibrary.Location = new System.Drawing.Point(119, 94);
            this.AddLibrary.Name = "AddLibrary";
            this.AddLibrary.Size = new System.Drawing.Size(57, 23);
            this.AddLibrary.TabIndex = 13;
            this.AddLibrary.Text = "添加";
            this.AddLibrary.UseVisualStyleBackColor = true;
            this.AddLibrary.Click += new System.EventHandler(this.AddLibrary_Click);
            // 
            // listBoxLibrary
            // 
            this.listBoxLibrary.FormattingEnabled = true;
            this.listBoxLibrary.ItemHeight = 12;
            this.listBoxLibrary.Location = new System.Drawing.Point(35, 123);
            this.listBoxLibrary.Name = "listBoxLibrary";
            this.listBoxLibrary.Size = new System.Drawing.Size(348, 40);
            this.listBoxLibrary.TabIndex = 12;
            // 
            // ImportGroupFiles
            // 
            this.ImportGroupFiles.Location = new System.Drawing.Point(35, 417);
            this.ImportGroupFiles.Name = "ImportGroupFiles";
            this.ImportGroupFiles.Size = new System.Drawing.Size(102, 23);
            this.ImportGroupFiles.TabIndex = 15;
            this.ImportGroupFiles.Text = "导入组和文件";
            this.ImportGroupFiles.UseVisualStyleBackColor = true;
            this.ImportGroupFiles.Click += new System.EventHandler(this.ImportGroupFiles_Click);
            // 
            // treeViewProgram
            // 
            this.treeViewProgram.Location = new System.Drawing.Point(566, 22);
            this.treeViewProgram.Name = "treeViewProgram";
            this.treeViewProgram.Size = new System.Drawing.Size(254, 394);
            this.treeViewProgram.TabIndex = 16;
            // 
            // GetSoftwareInfo
            // 
            this.GetSoftwareInfo.Location = new System.Drawing.Point(566, 434);
            this.GetSoftwareInfo.Name = "GetSoftwareInfo";
            this.GetSoftwareInfo.Size = new System.Drawing.Size(93, 23);
            this.GetSoftwareInfo.TabIndex = 17;
            this.GetSoftwareInfo.Text = "获取程序信息";
            this.GetSoftwareInfo.UseVisualStyleBackColor = true;
            //this.GetSoftwareInfo.Click += new System.EventHandler(this.GetSoftwareInfo_Click);
            // 
            // ImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 281);
            this.Controls.Add(this.GetSoftwareInfo);
            this.Controls.Add(this.treeViewProgram);
            this.Controls.Add(this.ImportGroupFiles);
            this.Controls.Add(this.labelLibrary);
            this.Controls.Add(this.AddLibrary);
            this.Controls.Add(this.listBoxLibrary);
            this.Controls.Add(this.labelXMLFile);
            this.Controls.Add(this.AddFile);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.labelCPUName);
            this.Controls.Add(this.textBoxCPUName);
            this.Controls.Add(this.buttonUpDate);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxExport);
            this.Name = "ImportExport";
            this.Text = "ImportExport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImportExport_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonUpDate;
        private System.Windows.Forms.Label labelCPUName;
        private System.Windows.Forms.TextBox textBoxCPUName;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button AddFile;
        private System.Windows.Forms.Label labelXMLFile;
        private System.Windows.Forms.Label labelLibrary;
        private System.Windows.Forms.Button AddLibrary;
        private System.Windows.Forms.ListBox listBoxLibrary;
        private System.Windows.Forms.Button ImportGroupFiles;
        private System.Windows.Forms.TreeView treeViewProgram;
        private System.Windows.Forms.Button GetSoftwareInfo;
    }
}