namespace TestFunctions
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.StartPortal = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.CreatProject = new System.Windows.Forms.Button();
            this.ConnectProject = new System.Windows.Forms.Button();
            this.AddStations = new System.Windows.Forms.Button();
            this.AddTotalStation = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ModuleImport = new System.Windows.Forms.Button();
            this.FunctionTest = new System.Windows.Forms.Button();
            this.CustomiztionImport = new System.Windows.Forms.Button();
            this.PlcSimAD = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PortalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.StartPortalMemu = new System.Windows.Forms.ToolStripMenuItem();
            this.打开项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接博图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerImport = new System.Windows.Forms.ToolStripMenuItem();
            this.pLCSIMAdvancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartPortal
            // 
            this.StartPortal.Location = new System.Drawing.Point(29, 54);
            this.StartPortal.Margin = new System.Windows.Forms.Padding(4);
            this.StartPortal.Name = "StartPortal";
            this.StartPortal.Size = new System.Drawing.Size(100, 31);
            this.StartPortal.TabIndex = 0;
            this.StartPortal.Text = "启动博途";
            this.StartPortal.UseVisualStyleBackColor = true;
            this.StartPortal.Click += new System.EventHandler(this.StartPortal_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(29, 478);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(4);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(558, 64);
            this.MessageBox.TabIndex = 2;
            this.MessageBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            // 
            // CreatProject
            // 
            this.CreatProject.Location = new System.Drawing.Point(29, 93);
            this.CreatProject.Margin = new System.Windows.Forms.Padding(4);
            this.CreatProject.Name = "CreatProject";
            this.CreatProject.Size = new System.Drawing.Size(100, 29);
            this.CreatProject.TabIndex = 3;
            this.CreatProject.Text = "创建项目";
            this.CreatProject.UseVisualStyleBackColor = true;
            this.CreatProject.Click += new System.EventHandler(this.CreatProject_Click);
            // 
            // ConnectProject
            // 
            this.ConnectProject.Location = new System.Drawing.Point(29, 129);
            this.ConnectProject.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectProject.Name = "ConnectProject";
            this.ConnectProject.Size = new System.Drawing.Size(100, 28);
            this.ConnectProject.TabIndex = 4;
            this.ConnectProject.Text = "连接博途";
            this.ConnectProject.UseVisualStyleBackColor = true;
            this.ConnectProject.Click += new System.EventHandler(this.ConnectProject_Click);
            // 
            // AddStations
            // 
            this.AddStations.Location = new System.Drawing.Point(1104, 399);
            this.AddStations.Margin = new System.Windows.Forms.Padding(4);
            this.AddStations.Name = "AddStations";
            this.AddStations.Size = new System.Drawing.Size(100, 29);
            this.AddStations.TabIndex = 5;
            this.AddStations.Text = "添加站点";
            this.AddStations.UseVisualStyleBackColor = true;
            this.AddStations.Click += new System.EventHandler(this.AddStations_Click);
            // 
            // AddTotalStation
            // 
            this.AddTotalStation.Location = new System.Drawing.Point(29, 165);
            this.AddTotalStation.Margin = new System.Windows.Forms.Padding(4);
            this.AddTotalStation.Name = "AddTotalStation";
            this.AddTotalStation.Size = new System.Drawing.Size(100, 29);
            this.AddTotalStation.TabIndex = 10;
            this.AddTotalStation.Text = "添加站点";
            this.AddTotalStation.UseVisualStyleBackColor = true;
            this.AddTotalStation.Click += new System.EventHandler(this.AddTotalStation_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(170, 54);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(417, 396);
            this.treeView1.TabIndex = 11;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // ModuleImport
            // 
            this.ModuleImport.Location = new System.Drawing.Point(1016, 271);
            this.ModuleImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModuleImport.Name = "ModuleImport";
            this.ModuleImport.Size = new System.Drawing.Size(100, 31);
            this.ModuleImport.TabIndex = 14;
            this.ModuleImport.Text = "模块化导入";
            this.ModuleImport.UseVisualStyleBackColor = true;
            this.ModuleImport.Click += new System.EventHandler(this.ModuleImport_Click);
            // 
            // FunctionTest
            // 
            this.FunctionTest.Location = new System.Drawing.Point(724, 459);
            this.FunctionTest.Margin = new System.Windows.Forms.Padding(4);
            this.FunctionTest.Name = "FunctionTest";
            this.FunctionTest.Size = new System.Drawing.Size(100, 29);
            this.FunctionTest.TabIndex = 15;
            this.FunctionTest.Text = "功能测试";
            this.FunctionTest.UseVisualStyleBackColor = true;
            this.FunctionTest.Click += new System.EventHandler(this.FunctionTest_Click);
            // 
            // CustomiztionImport
            // 
            this.CustomiztionImport.Location = new System.Drawing.Point(29, 202);
            this.CustomiztionImport.Margin = new System.Windows.Forms.Padding(4);
            this.CustomiztionImport.Name = "CustomiztionImport";
            this.CustomiztionImport.Size = new System.Drawing.Size(100, 31);
            this.CustomiztionImport.TabIndex = 17;
            this.CustomiztionImport.Text = "定制化导入";
            this.CustomiztionImport.UseVisualStyleBackColor = true;
            this.CustomiztionImport.Click += new System.EventHandler(this.CustomiztionImport_Click);
            // 
            // PlcSimAD
            // 
            this.PlcSimAD.Location = new System.Drawing.Point(29, 241);
            this.PlcSimAD.Margin = new System.Windows.Forms.Padding(4);
            this.PlcSimAD.Name = "PlcSimAD";
            this.PlcSimAD.Size = new System.Drawing.Size(100, 31);
            this.PlcSimAD.TabIndex = 18;
            this.PlcSimAD.Text = "PlcSimAD";
            this.PlcSimAD.UseVisualStyleBackColor = true;
            this.PlcSimAD.Click += new System.EventHandler(this.PlcSimAD_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortalMenu,
            this.toolStripMenuItem2,
            this.pLCSIMAdvancedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(621, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PortalMenu
            // 
            this.PortalMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartPortalMemu,
            this.打开项目ToolStripMenuItem,
            this.创建项目ToolStripMenuItem,
            this.连接博图ToolStripMenuItem,
            this.添加站点ToolStripMenuItem});
            this.PortalMenu.Name = "PortalMenu";
            this.PortalMenu.Size = new System.Drawing.Size(81, 24);
            this.PortalMenu.Text = "博途功能";
            // 
            // StartPortalMemu
            // 
            this.StartPortalMemu.Name = "StartPortalMemu";
            this.StartPortalMemu.Size = new System.Drawing.Size(216, 26);
            this.StartPortalMemu.Text = "开启博途";
            this.StartPortalMemu.Click += new System.EventHandler(this.StartPortalMemu_Click);
            // 
            // 打开项目ToolStripMenuItem
            // 
            this.打开项目ToolStripMenuItem.Name = "打开项目ToolStripMenuItem";
            this.打开项目ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.打开项目ToolStripMenuItem.Text = "打开项目";
            // 
            // 创建项目ToolStripMenuItem
            // 
            this.创建项目ToolStripMenuItem.Name = "创建项目ToolStripMenuItem";
            this.创建项目ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.创建项目ToolStripMenuItem.Text = "创建项目";
            // 
            // 连接博图ToolStripMenuItem
            // 
            this.连接博图ToolStripMenuItem.Name = "连接博图ToolStripMenuItem";
            this.连接博图ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.连接博图ToolStripMenuItem.Text = "连接博途";
            // 
            // 添加站点ToolStripMenuItem
            // 
            this.添加站点ToolStripMenuItem.Name = "添加站点ToolStripMenuItem";
            this.添加站点ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.添加站点ToolStripMenuItem.Text = "添加站点";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerImport});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 24);
            this.toolStripMenuItem2.Text = "导入导出功能";
            // 
            // CustomerImport
            // 
            this.CustomerImport.Name = "CustomerImport";
            this.CustomerImport.Size = new System.Drawing.Size(216, 26);
            this.CustomerImport.Text = "定制化导入";
            this.CustomerImport.Click += new System.EventHandler(this.CustomerImport_Click);
            // 
            // pLCSIMAdvancedToolStripMenuItem
            // 
            this.pLCSIMAdvancedToolStripMenuItem.Name = "pLCSIMAdvancedToolStripMenuItem";
            this.pLCSIMAdvancedToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.pLCSIMAdvancedToolStripMenuItem.Text = "PLCSIM Advanced";
            this.pLCSIMAdvancedToolStripMenuItem.Click += new System.EventHandler(this.pLCSIMAdvancedToolStripMenuItem_Click);
            // 
            // 下载
            // 
            this.下载.Location = new System.Drawing.Point(29, 279);
            this.下载.Name = "下载";
            this.下载.Size = new System.Drawing.Size(100, 32);
            this.下载.TabIndex = 20;
            this.下载.Text = "下载";
            this.下载.UseVisualStyleBackColor = true;
            this.下载.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(621, 557);
            this.Controls.Add(this.下载);
            this.Controls.Add(this.PlcSimAD);
            this.Controls.Add(this.CustomiztionImport);
            this.Controls.Add(this.FunctionTest);
            this.Controls.Add(this.ModuleImport);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.AddTotalStation);
            this.Controls.Add(this.AddStations);
            this.Controls.Add(this.ConnectProject);
            this.Controls.Add(this.CreatProject);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.StartPortal);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "集成测试系统";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartPortal;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button CreatProject;
        private System.Windows.Forms.Button ConnectProject;
        private System.Windows.Forms.Button AddStations;
        private System.Windows.Forms.Button AddTotalStation;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button ModuleImport;
        private System.Windows.Forms.Button FunctionTest;
        private System.Windows.Forms.Button CustomiztionImport;
        private System.Windows.Forms.Button PlcSimAD;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PortalMenu;
        private System.Windows.Forms.ToolStripMenuItem StartPortalMemu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 打开项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接博图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomerImport;
        private System.Windows.Forms.ToolStripMenuItem pLCSIMAdvancedToolStripMenuItem;
        private System.Windows.Forms.Button 下载;
    }
}

