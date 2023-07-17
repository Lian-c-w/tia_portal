using System;
using System.Windows.Forms;
using FunctionManager;
using FormManager;
using FileManager;
using Siemens.Engineering.HW;
using Siemens.Engineering;

namespace TestFunctions
{
    public partial class Form1 : Form
    {
        //private FunctionManager.FunctionManager myFM = new FunctionManager.FunctionManager();
        //private CreateProjectForm1 CPF;
        //public string mySelectString { get; set; }
        public ModuleImport myModuleImport { get; set; }
        public ImportExport myImportExport { get; set; }
        public PlcTag myPlcTag { get; set; }
        public CustomizationImport myCImport { get; set; }
        private FormPlcSimAD myFromPlcSimAD;
        private TiaPortalEX myTiaPortalEX = new TiaPortalEX();
        private DownLoad myDownload;
        public Form1()
        {
            InitializeComponent();
            myTiaPortalEX.MyprogressInformation.MytextBox = MessageBox;
            myTiaPortalEX.MyprogressInformation.Myform = this;
            //myTiaPortalEX.InitializeEvent();          
            

        }

        private void StartPortal_Click(object sender, EventArgs e)
        {
            //myTiaPortalEX = new TiaPortalEX();         
            MessageBox.Text = myTiaPortalEX.Start();
            myTiaPortalEX.InitializeEvent();
            //启动博途后功能可以使用
            //AddTotalStation.Enabled = true;
            //CustomiztionImport.Enabled = true;
            //下载.Enabled = true;
            CreatProject.Enabled = true;
        }

        private void OpenProject_Click(object sender, EventArgs e)
        {
            //MessageBox.Text = myTiaPortalEX.OpenProject();            
        }

        private void CreatProject_Click(object sender, EventArgs e)
        {
 
            CreateProject cpf = new CreateProject();
            cpf.myTiaPortalEX = myTiaPortalEX;
            cpf.ShowDialog();
            //创建项目后功能可以使用
            AddTotalStation.Enabled = true;
            CustomiztionImport.Enabled = true;
            下载.Enabled = true;

        }
        private void ConnectProject_Click(object sender, EventArgs e)
        {
            MessageBox.Clear();
            try
            {
                //myFM.ConnectProject();
                //myFM.GetTreeView(treeView1);
                //MessageBox.Text = myFM.StatusText;
                //myTiaPortalEX = new TiaPortalEX();
                MessageBox.Text = myTiaPortalEX.ConnectTiaPortal();
                GetTreeView();
                myTiaPortalEX.InitializeEvent();
                //连接博途后功能可以使用
                AddTotalStation.Enabled = true;
                CustomiztionImport.Enabled = true;
                下载.Enabled = true;
            }
            catch (Exception exp)
            {
                //MessageBox.Text = exp.Message;
            }
        }

        private void AddStations_Click(object sender, EventArgs e)
        {
            
            //AddStations adds = new AddStations(myFM);
            //adds.Show();
            //MessageBox.Text = myFM.StatusText;
            //adds.Show();
        }

        private void testbutton_Click(object sender, EventArgs e)
        {
            //ExcelManager em = new ExcelManager();
            //em.GetData();
        }             
      

        private void AddTotalStation_Click(object sender, EventArgs e)
        {            
            AddStationTotal addst = new AddStationTotal(treeView1,this);
            addst.myTiaPortalEX = myTiaPortalEX;
            addst.ShowDialog();             
        }

        private void refresh_Click(object sender, EventArgs e)//刷新项目结构信息
        {            
            //myFM.GetTreeView(treeView1);
           // Refresh();
        }
        public void RefreshTV()
        {
            //myFM.GetTreeView(treeView1);
        }

        private void ImportExport_Click(object sender, EventArgs e)
        {
            myImportExport = new ImportExport();
            myImportExport.myTiaPortalEX = myTiaPortalEX;
            myImportExport.Show();
        }

        private void ModuleImport_Click(object sender, EventArgs e)
        {
            //myModuleImport = new ModuleImport(myFM);
            myModuleImport.Show();
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
 
        }
        /// <summary>
        /// 获取项目中的CPU名称，并更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //FunctionManager.PublicFunctions pf = new FunctionManager.PublicFunctions();
            if (myModuleImport != null)
            {
                PublicFunctions.UpdateMessage += myModuleImport.UpdateCpuName;
            }
            if (myImportExport != null)
            {
                PublicFunctions.UpdateMessage += myImportExport.UpdateCpuName;
            }
            if (myCImport != null)
            {
                PublicFunctions.UpdateMessage += myCImport.UpdateCpuName;
            }
            if (myFromPlcSimAD != null)
            {
                PublicFunctions.UpdateMessage += myFromPlcSimAD.UpdateCpuName;
            }
            //触发事件
            PublicFunctions.StartMessage(treeView1.SelectedNode.Text);

        }
        /// <summary>
        /// 测试功能使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctionTest_Click(object sender, EventArgs e)
        {
            //MasterType mt = new MasterType();
            //mt.Name = "stationCPU";
            // NetParameter np = new NetParameter();
            // np.Modes = "PN/IE";
            // np.Number = 1;
            // np.PcInterface = "Intel(R) PRO/1000 MT Network Connection";
            // np.TargetInterface = "1 X1";
            //  myFM.ConnectPLC(mt, np);
            //myFM.DownLoad(mt, np);
            //MasterType mt = new MasterType();
            // mt.Name = "SINAMICS G_1";
            // mt.DeviceName = "adsfddgdf";
            // myFM.ChangeDeviceName(mt);  
            //myFM.AccessDrvPara();
                       
        }
        /// <summary>
        /// 变量导入导出操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTagFunction_Click(object sender, EventArgs e)
        {
            //myPlcTag = new PlcTag(myFM);
            //myPlcTag.Show();
        }

        private void CustomiztionImport_Click(object sender, EventArgs e)
        {
            myCImport = new CustomizationImport();
            myCImport.myTiaPortalEX = myTiaPortalEX;
            myCImport.ShowDialog();
        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlcSimAD_Click(object sender, EventArgs e)
        {
            myFromPlcSimAD = new FormPlcSimAD ();
            myFromPlcSimAD.ShowDialog();
        }

        private void StartPortalMemu_Click(object sender, EventArgs e)
        {
            //myTiaPortalEX = new TiaPortalEX();
            MessageBox.Text = myTiaPortalEX.Start();
        }

        static private void GetTree(TreeNode tn, DeviceItem di)
        {
            //TreeNode node = new TreeNode(di.Name);
            //TreeNode sutn = tn
            TreeNode sutn = tn.Nodes.Add(di.Name);
            foreach (DeviceItem deitem in di.DeviceItems)
            {
                GetTree(sutn, deitem);
            }
        }
        public string GetTreeView()
        {
            Project project = myTiaPortalEX.GetProjectEX().myProject;
            treeView1.Nodes.Clear();
            foreach (Device device in project.Devices)
            {
                //TreeNode node = new TreeNode(device.Name);
                //TreeNode tn1 = (TreeNode)tv.Invoke(new AddnodeHand(tv.Nodes.Add), new object[] { node });
                TreeNode tn1 = treeView1.Nodes.Add(device.Name);
                //TreeNode tn1 = tv.Invoke(Add,device.Name);
                foreach (DeviceItem deitem in device.DeviceItems)
                {
                    GetTree(tn1, deitem);
                }
            }
            foreach (DeviceUserGroup dug in project.DeviceGroups)
            {
                TreeNode tn = treeView1.Nodes.Add(dug.Name);
                foreach (Device device in dug.Devices)
                {
                    TreeNode tn1 = tn.Nodes.Add(device.Name);
                    foreach (DeviceItem deitem in device.DeviceItems)
                    {
                        GetTree(tn1, deitem);
                    }
                }
            }
            return null;
        }

        private void CustomerImport_Click(object sender, EventArgs e)
        {
            myCImport = new CustomizationImport();
            myCImport.myTiaPortalEX = myTiaPortalEX;
            myCImport.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDownload = new DownLoad();
            myDownload.myTiaPortalEX = myTiaPortalEX;
            myDownload.ShowDialog();
        }

        private void pLCSIMAdvancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myFromPlcSimAD = new FormPlcSimAD();
            myFromPlcSimAD.Show();
        }
        //在没有打开或者连接portal的情况下，不激活某些按钮
        private void Form1_Shown(object sender, EventArgs e)
        {
            CreatProject.Enabled = false;
            AddTotalStation.Enabled = false;
            CustomiztionImport.Enabled = false;
            下载.Enabled = false;
        }

    }
}

