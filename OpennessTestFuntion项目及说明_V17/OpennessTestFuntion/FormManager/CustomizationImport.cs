using System;
using System.IO;
using Siemens.Engineering.SW.Blocks;
using System.Windows.Forms;
using FunctionManager;
using FileManager;
using System.Threading;

namespace FormManager
{
    public partial class CustomizationImport : Form
    {        
        private Factory myFactory = new Factory();
        private ProgressInformation MyprogressInformation = new ProgressInformation();
        public TiaPortalEX myTiaPortalEX { get; set; }        

        public CustomizationImport()
        {
            InitializeComponent();
            MyprogressInformation.Myform = this;
            MyprogressInformation.MyprogressBar = progressBar1;
            MyprogressInformation.MytextBox = InformationText;
            //InitializeComponent();
        }
        /// <summary>
        /// 获取选择状态
        /// </summary>
        private void JudgebFlags()
        {          
           if(checkBoxWater1.Checked || checkBoxOil1.Checked)
            {
                Workshop ws = new Workshop();
                ws.Name = "车间1";
                //ws.BlockName = "Workshop1";
                //ws.Path = new DirectoryInfo(textBoxPath.Text + @"CI\" + ws.Name);
                if (checkBoxWater1.Checked)
                {
                    TankType tk = new TankType();
                    tk.Name = "水罐1";
                    //tk.BlockName = "Tank_Water1";
                    tk.TypeName = "Water";
                    ws.Add(tk);
                    //ws.Tanks.
                    //ws.Tanks.Add(tk);
                }
                if(checkBoxOil1.Checked)
                {
                    TankType tk = new TankType();
                    tk.Name = "油罐1";
                    //tk.BlockName = "Tank_Oil1";
                    tk.TypeName = "Oil";
                    ws.Add(tk);
                    //ws.Tanks.Add(tk);
                }
                myFactory.Add(ws);                
                //myFactory.Workshops.Add(ws);
            }

            if (checkBoxWater2.Checked || checkBoxOil2.Checked)
            {
                Workshop ws = new Workshop();
                ws.Name = "车间2";
                //ws.BlockName = "Workshop2";
                //ws.Path = new DirectoryInfo(textBoxPath.Text + @"CI\" + ws.Name);
                if (checkBoxWater2.Checked)
                {
                    TankType tk = new TankType();
                    tk.Name = "水罐2";
                    //tk.BlockName = "Tank_Water2";
                    tk.TypeName = "Water";
                    ws.Add(tk);
                    //ws.Tanks.Add(tk);
                }
                if (checkBoxOil2.Checked)
                {
                    TankType tk = new TankType();
                    tk.Name = "油罐2";
                    //tk.BlockName = "Tank_Oil2";
                    tk.TypeName = "Oil";
                    ws.Add(tk);
                    //ws.Tanks.Add(tk);
                }
                myFactory.Add(ws);
               // myFactory.Workshops.Add(ws);
            }
        }  

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(ConfirmFunction);
            //t.IsBackground = true;
            //t.Start();
            ConfirmFunction();
        }
       
        private void ConfirmFunction()
        {
            myFactory.Reset();           
            JudgebFlags();
            int BlockCount = myFactory.Count();//统计工厂中对象的个数
            MyprogressInformation.CountProgressBar(BlockCount);//初始化ProgressBar
            MyprogressInformation.ClearTextBox();//初始化TextBox
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = BlockCount + 1;
            //progressBar1.Value = 0;
            StationType station = null;
            //导入库文件

            if (textBoxPath.Text != "")
            {
                myFactory.BlockPath = textBoxPath.Text;//工厂中的XML文件路径
            }
            else
            {
                MyprogressInformation.TextBoxAdd("没有设置XML文件路径");
            }
            //FileInfo libpath = new FileInfo(textBoxLibrary.Text);
            if (textBoxLibrary.Text != "")
            {
                FileInfo libpath = new FileInfo(textBoxLibrary.Text);
                string result1 = myTiaPortalEX.ImportGlobalLibrary(libpath);//按照路径导入全局库，并生成全局库对象
                string result2 = myTiaPortalEX.CopyMasterCopies();//拷贝全局库中的主模版到项目库中
                MyprogressInformation.TextBoxAdd(result1);
                MyprogressInformation.TextBoxAdd(result2);
            }
            else
            {
                MyprogressInformation.TextBoxAdd("没有设置库路径");
            }
            ProjectEX projectEX = myTiaPortalEX.GetProjectEX();//获取Portal对象中的projectEX对象
            if (projectEX != null)
            {
                projectEX.CreateDeFormMasterCopies("HMI_1");//将主模版中的"HMI_1"添加到项目中
                                                            //station = projectEX.GetStation(textBoxCPUName.Text);//根据名称获取站点中的站对象
                station = projectEX.GetStation();
                if (station != null)
                {
                    station.MyprogressInformation = MyprogressInformation;//连接过程信息对象
                    station.ImportBlockFromGlobalLibrary(myTiaPortalEX.myGlobalLibrary);//将全局库导入该站点
                    station.ImportBlockFromXML(myFactory);//导入XML文件生成功能块 
                }
                else
                {
                    MyprogressInformation.TextBoxAdd("项目中没有添加CPU");
                }
            }
            else
            {
                MyprogressInformation.TextBoxAdd("没有打开或者连接博途项目");
            }

            if (station != null)
            {
                station.CompileSoftWare();//导入完成后，编译软件
            }
        }

        private void LibraryUpdate_Click(object sender, EventArgs e)
        { 
            StationType station = null;
            try
            {
                FileInfo libpath = new FileInfo(textBoxLibrary.Text);
                //if (myTiaPortalEX.myGlobalLibrary == null)
                //{
                    myTiaPortalEX.ImportGlobalLibrary(libpath);//按照路径导入全局库，并生成全局库对象
               // }
                ProjectEX projectEX = myTiaPortalEX.GetProjectEX();//获取Portal对象中的projectEX对象
                //station = projectEX.GetStation(textBoxCPUName.Text);//根据名称获取站点中的站对象.
                station = projectEX.GetStation();
                station.LibraryUpdate(myTiaPortalEX.myGlobalLibrary);//更新全局库到功能块                
            }
            catch (Exception exp)
            {
                MyprogressInformation.TextBoxAdd("没有打开或者连接博途项目");
            }
            if (station != null)
            {
                station.CompileSoftWare();//导入完成后，编译软件
            }

        }
        public void UpdateCpuName(string info)
        {
            textBoxCPUName.Text = info;
            Refresh();
        }
        //关闭倒入窗口时，关闭打开的全局库
        private void CustomizationImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                myTiaPortalEX.CloseLibrary();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void CustomizationImport_Load(object sender, EventArgs e)
        {

        }

        private void DeleteAllBlocks_Click(object sender, EventArgs e)
        {
            ProjectEX projectEX = myTiaPortalEX.GetProjectEX();//获取Portal对象中的projectEX对象
                                                               //StationType station = projectEX.GetStation(textBoxCPUName.Text);//根据名称获取站点中的站对象
            StationType station = projectEX.GetStation();
            if (station != null)
            {
                //StationType station = projectEX.GetStation();
                station.MyprogressInformation = MyprogressInformation;
                MyprogressInformation.ClearTextBox();
                //Thread tt = new Thread(station.DeleteAllBlocks);
                //t.IsBackground = true;
                //tt.Start();
                station.DeleteAllBlocks();
                station.MyprogressInformation = MyprogressInformation;
                MyprogressInformation.ClearTextBox();
                //Thread tt = new Thread(station.DeleteAllBlocks);
                //t.IsBackground = true;
                //tt.Start();
                station.DeleteAllBlocks();
            }
            else
            {
                MyprogressInformation.TextBoxAdd("没有打开或者连接博途项目");
            }
           
        }
    }
}
