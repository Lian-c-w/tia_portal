using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW;
//using Siemens.Engineering.mc;
using FileManager;
using Siemens.Engineering.Download;


namespace FunctionManager
{
    public class FunctionManager
    {
        //private static TiaPortalProcess tiaProcess;
        /// <summary>
        /// 设置是否启用Portal界面
        /// </summary>
        //public bool PortalUI { get; set; }
        //public string StatusText { get; set; }
        //public TiaPortal MyTiaPortal { get; set; }
        public Project MyProject { get; set; }
        //public bool SubNet { get; set; }
        //public bool PNIO { get; set; }
        //public bool Topu { get; set; }
        //public ExcelManager myEM { get; set; }
        //public ProgressBar myPB { get; set; }
        //public TreeView myTV { get; set; }
        public Form myForm { get; set; }
        public TextBox myTB { get; set; }//输出添加信息
        public StationType myCPU { get; set; }//CPU模块信息



        /// <summary>
        /// 启动Portal
        /// </summary>
        //public string StartPortal()
        //{
        //    if (PortalUI == true)
        //    {
        //        MyTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);

        //        tiaProcess = TiaPortal.GetProcesses()[0];
        //        return "TIA Portal started without user interface";
        //    }
        //    else
        //    {
        //        MyTiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);
        //        return "TIA Portal started with user interface";
        //    }
        //}
        /// <summary>
        /// 打开项目
        /// </summary>
        /// <returns></returns>
        //public string OpenProject()
        //{
        //    OpenFileDialog fileSearch = new OpenFileDialog();
        //    fileSearch.Filter = "*.ap15|*.ap15";
        //    fileSearch.RestoreDirectory = true;
        //    fileSearch.ShowDialog();
        //    string ProjectPath = fileSearch.FileName.ToString();
        //    if (string.IsNullOrEmpty(ProjectPath) == false)
        //    {
        //        try
        //        {
        //            MyProject = MyTiaPortal.Projects.Open(new FileInfo(ProjectPath));
        //            return "Project " + ProjectPath + " opened";

        //        }
        //        catch (Exception ex)
        //        {
        //            return "Error while opening project" + ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        /// <summary>
        /// 创建项目
        /// </summary>
        /// <returns></returns>
        //public string CreatProject(string path, string name)
        //{
        //    try
        //    {
        //        if (MyTiaPortal.Projects.Count <= 0)
        //        {
        //            ProjectComposition projectComposition = MyTiaPortal.Projects;
        //            DirectoryInfo targetDirectory = new DirectoryInfo(path);
        //            MyProject = projectComposition.Create(targetDirectory, name);
        //            StatusText = "项目正常创建";
        //        }
        //        else
        //        {
        //            StatusText = "项目已经创建";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        StatusText = e.Message;
        //    }

        //    return "";
        //}
        //public string ConnectProject()
        //{
        //    IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
        //    switch (processes.Count)
        //    {
        //        case 1:
        //            tiaProcess = processes[0];
        //            MyTiaPortal = tiaProcess.Attach();
        //            if (MyTiaPortal.GetCurrentProcess().Mode == TiaPortalMode.WithUserInterface)
        //            {
        //                //rdb_WithUI.Checked = true;
        //                //return "";                      
        //            }
        //            else
        //            {
        //                //rdb_WithoutUI.Checked = true;
        //                //return "";
        //            }


        //            if (MyTiaPortal.Projects.Count <= 0)
        //            {

        //                StatusText = "No TIA Portal Project was found!";
        //            }
        //            else
        //            {
        //                MyProject = MyTiaPortal.Projects[0];
        //                StatusText = "成功连接Portal";
        //            }
        //            break;
        //        case 0:
        //            return "No running instance of TIA Portal was found!";

        //        default:
        //            return "More than one running instance of TIA Portal was found!";

        //    }
        //    return "";
        //}
        //public string AddStationCPU(StationType cpu)
        //{
        //    //mySFunc = new StationsFunction();
        //    return StationsFunction.AddCPU(cpu, MyProject);
        //    //StatusText = mySFunc.StatusText;
        //    //return mySFunc.StatusText;
        //}
        //public string AddStationModule(StationType mt, Moduletype md)
        //{
        //    if ((mt.type == "G") || (mt.type == "S"))
        //    {
        //        return StationsFunction.AddDrvModule(mt, md, MyProject);
        //        //return null;
        //    }
        //    else
        //    {
        //        return StationsFunction.AddModule(mt, md, MyProject);
        //    }
        //}
        //public string AddMasterModule(StationType infa, ProgressBar pb, TextBox tb, Form fm)
        //{
        //    if ((infa.type == "G") || (infa.type == "S"))
        //    {
        //        return StationsFunction.AddDrvMasterModule(infa, MyProject, pb, tb, fm);
        //    }
        //    else
        //    {
        //        return StationsFunction.AddMasterModule(infa, MyProject, pb, tb, fm);
        //    }
        //}
        //private bool JudgeInterface(string ifName)
        //{
        //    bool flag = false;
        //    bool Flag = false;
        //    List<string> interfaces = new List<string>();
        //    interfaces.Add("PROFINET 接口_1");
        //    interfaces.Add("PROFINET 接口");
        //    interfaces.Add("PROFINET interface_1");
        //    interfaces.Add("PROFINET interface");
        //    foreach (string st in interfaces)
        //    {
        //        if (ifName == st)
        //        {
        //            flag = true;
        //        }
        //        Flag = Flag || flag;
        //    }
        //    return Flag;
        //}
        //public string AddNet(string netname, StationType mt)
        //{
        //    Subnet newsubnet = null;
        //    NetworkInterface networkInterface = null;
        //    string MLFB = "OrderNumber:" + mt.OderNo + "/" + mt.Version;
        //    string name = mt.Name;
        //    string devname = "station" + mt.Name;

        //    try
        //    {
        //        newsubnet = MyProject.Subnets.Create("System:Subnet.Ethernet", netname);
        //    }
        //    catch (Exception)
        //    {
        //        ;
        //    }

        //    try
        //    {
        //        newsubnet = MyProject.Subnets.Find(netname);
        //    }
        //    catch (Exception)
        //    {
        //        ;
        //    }

        //    try
        //    {
        //        if (mt.type == "G")
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find("SINAMICS G_1").DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    networkInterface.Nodes.First().SetAttribute("Address", mt.IPAdress);
        //                    try
        //                    {
        //                        networkInterface.Nodes.First().ConnectToSubnet(newsubnet);
        //                        StatusText = "成功连接";
        //                    }
        //                    catch (Exception exp)
        //                    {
        //                        StatusText = exp.Message;
        //                    }
        //                }
        //            }

        //        }
        //        else
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find(devname).DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    networkInterface.Nodes.First().SetAttribute("Address", mt.IPAdress);
        //                    try
        //                    {
        //                        networkInterface.Nodes.First().ConnectToSubnet(newsubnet);
        //                        StatusText = "成功连接";
        //                    }
        //                    catch (Exception exp)
        //                    {
        //                        StatusText = exp.Message;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        StatusText = exp.Message; ;
        //    }
        //    return StatusText;
        //}
        //public string AddIOSys(string netname, string IOname, StationType mt)
        //{
        //    Subnet newsubnet = null;
        //    NetworkInterface networkInterface = null;
        //    IoSystem ioSystem = null;
        //    string MLFB = "OrderNumber:" + mt.OderNo + "/" + mt.Version;
        //    string name = mt.Name;
        //    string devname = "station" + mt.Name;

        //    try
        //    {
        //        newsubnet = MyProject.Subnets.Find(netname);
        //    }
        //    catch (Exception exp)
        //    {
        //        StatusText = exp.Message;
        //    }

        //    try
        //    {
        //        foreach (DeviceItem deviceItem in MyProject.Devices.Find(devname).DeviceItems[1].DeviceItems)
        //        {
        //            if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1"|| deviceItem.Name == "PROFINET 接口")
        //            {
        //                networkInterface = deviceItem.GetService<NetworkInterface>();
        //                if ((networkInterface.InterfaceOperatingMode & InterfaceOperatingModes.IoController) != 0)
        //                {
        //                    IoController ioController = networkInterface.IoControllers.First();
        //                    if (ioController != null)
        //                    {
        //                        try
        //                        {
        //                            ioSystem = ioController.CreateIoSystem(IOname);
        //                        }
        //                        catch (Exception exp)
        //                        {
        //                            StatusText = exp.Message;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        StatusText = exp.Message;
        //    }

        //    try
        //    {
        //        if (mt.type == "G")
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find("SINAMICS G_1").DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1"||deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    IoSystem _ioSystem = newsubnet.IoSystems[0];
        //                    try
        //                    {
        //                        networkInterface.IoConnectors.First().ConnectToIoSystem(_ioSystem);
        //                    }
        //                    catch (Exception exp)
        //                    {
        //                        StatusText = exp.Message;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find(devname).DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1"||deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    IoSystem _ioSystem = newsubnet.IoSystems[0];
        //                    try
        //                    {
        //                        networkInterface.IoConnectors.First().ConnectToIoSystem(_ioSystem);
        //                    }
        //                    catch (Exception exp)
        //                    {
        //                        StatusText = exp.Message;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        StatusText = exp.Message;
        //    }

        //    return StatusText;
        //}
        //public string AddTopoCn(StationType mt1, StationType mt2)
        //{
        //    NetworkInterface networkInterface = null;
        //    NetworkPort port1 = null;
        //    NetworkPort port2 = null;
        //    //string MLFB = "OrderNumber:" + mt.OderNo + "/" + mt.Version;
        //    //string name = mt.Name;
        //    string devname1 = "station" + mt1.Name;
        //    string devname2 = "station" + mt2.Name;

        //    try
        //    {
        //        if (mt1.type == "G")
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find("SINAMICS G_1").DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1"||deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    port1 = networkInterface.Ports[mt1.ConPort];
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find(devname1).DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1"||deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    port1 = networkInterface.Ports[mt1.ConPort];
        //                }
        //            }
        //        }
        //        if (mt2.type == "G")
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find("SINAMICS G_1").DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    port2 = networkInterface.Ports[mt2.ConPort];
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (DeviceItem deviceItem in MyProject.Devices.Find(devname2).DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    port2 = networkInterface.Ports[mt2.ConPort];
        //                }
        //            }
        //        }
        //        port1.ConnectToPort(port2);
        //    }
        //    catch (Exception exp)
        //    {
        //        StatusText = exp.Message;
        //    }

        //    return StatusText;
        //}
        //delegate int AddnodeHand(TreeNode node);
        //static private void GetTree(TreeNode tn, DeviceItem di)
        //{
        //    //TreeNode node = new TreeNode(di.Name);
        //    //TreeNode sutn = tn
        //    TreeNode sutn = tn.Nodes.Add(di.Name);
        //    foreach (DeviceItem deitem in di.DeviceItems)
        //    {
        //        GetTree(sutn, deitem);
        //    }
        //}
        //public string GetTreeView(TreeView tv)
        //{
        //    tv.Nodes.Clear();
        //    foreach (Device device in MyProject.Devices)
        //    {
        //        //TreeNode node = new TreeNode(device.Name);
        //        //TreeNode tn1 = (TreeNode)tv.Invoke(new AddnodeHand(tv.Nodes.Add), new object[] { node });
        //        TreeNode tn1 = tv.Nodes.Add(device.Name);
        //        //TreeNode tn1 = tv.Invoke(Add,device.Name);
        //        foreach (DeviceItem deitem in device.DeviceItems)
        //        {
        //            GetTree(tn1, deitem);
        //        }
        //    }
        //    foreach (DeviceUserGroup dug in MyProject.DeviceGroups)
        //    {
        //        TreeNode tn = tv.Nodes.Add(dug.Name);
        //        foreach (Device device in dug.Devices)
        //        {
        //            TreeNode tn1 = tn.Nodes.Add(device.Name);
        //            foreach (DeviceItem deitem in device.DeviceItems)
        //            {
        //                GetTree(tn1, deitem);
        //            }
        //        }
        //    }
        //    return StatusText;
        //}
        //public string GetSFWTreeView(string CPUName, TreeView tv)
        //{
        //    PlcSoftware plcSoftware = CGetSW.GetSW(CPUName, MyProject);
        //    tv.Nodes.Clear();
        //    foreach (PlcBlock pb in plcSoftware.BlockGroup.Blocks)
        //    {
        //        TreeNode tn1 = tv.Nodes.Add(pb.Name);
        //    }
        //    foreach (PlcBlockGroup pbg in plcSoftware.BlockGroup.Groups)
        //    {
        //        TreeNode tn1 = tv.Nodes.Add(pbg.Name);
        //    }
        //    //foreach (TechnologicalInstanceDB pbg in plcSoftware.TechnologicalObjectGroup.TechnologicalObjects)
        //    //{
        //    //    TreeNode tn1 = tv.Nodes.Add(pbg.Name);
        //    //}
        //    return "";
        //}
        //public string XMLImport(string CPUName, FileInfo path)
        //{

        //    return XMLFunction.XMLImport(CPUName, MyProject, path);

        //}
        //public string XMLImport(PlcBlockGroup pbg, FileInfo path)
        //{
        //    return XMLFunction.XMLImport(pbg, path);
        //}
        //public string XMLExport(string CPUName, FileInfo path)
        //{

        //    return XMLFunction.XMLExport(CPUName, MyProject, path);

        //}
        //public string LibraryImport(string CPUName, FileInfo path)
        //{
        //    //myLibFunc = new LibraryFunction();
        //    return LibraryFunction.LibraryImport(CPUName, MyTiaPortal, MyProject, path);
        //    //return myLibFunc.StatusText;
        //}
        //public string LibraryUpdate(string CPUName, FileInfo path)
        //{
        //    //myLibFunc = new LibraryFunction();
        //    return LibraryFunction.LibraryUpdate(CPUName, MyTiaPortal, MyProject, path);
        //    //return myLibFunc.StatusText;
        //}
        /// <summary>
        /// 软件编译功能
        /// </summary>
        /// <param name="CPUName"></param>
        //public void SWCompile(string CPUName)
        //{
        //    CGetSW.Compile(CPUName, MyProject);
        //}
        //public string CopyMasterCopies(FileInfo path)
        //{
        //    //myLibFunc = new LibraryFunction();
        //    LibraryFunction.DeleteMasterCopiesFromProjecLib(MyProject);//先删除项目库中的主拷贝
        //    return LibraryFunction.CopyMasterCopies(MyTiaPortal, MyProject, path);
        //    //return myLibFunc.StatusText;
        //}
        //public string CloseLibrary()
        //{
        //    //myLibFunc = new LibraryFunction();
        //    return LibraryFunction.CloseLibrary(MyTiaPortal);
        //    //return myLibFunc.StatusText;
        //}
        /// <summary>
        /// 使用主拷贝建立设备（HMI)
        /// </summary>
        /// <returns></returns>
        //public string CreateDeFromMasterCopies()
        //{
        //    //myLibFunc = new LibraryFunction();
        //    return LibraryFunction.CreateDeFormMasterCopies(MyProject);
        //    //return myLibFunc.StatusText;
        //}
        //public PlcBlockGroup CreateGroup(PlcBlockGroup plcbg, string group)
        //{
        //    return XMLFunction.CreateGroup(plcbg, group);
        //}
        //public PlcBlockGroup GetGroup(string CPUName)
        //{
        //    return XMLFunction.GetGroup(CPUName, MyProject);
        //}
        /// <summary>
        /// 更改设备名称
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="devicename"></param>
        public void ChangeDeviceName(StationType mt)
        {
            //mySFunc = new StationsFunction();            
            StationsFunction.ChangeDeviceName(mt, MyProject);
        }
        /// <summary>
        /// 下载功能
        /// </summary>
        /// <param name="CPUName"></param>
        /// <param name="NetCardName"></param>
        public void DownLoad(StationType mt, NetParameter np)
        {
            PLCAccess pa = new PLCAccess();
            deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
            DownloadResult dr = pa.Download(mt, MyProject, np);
            if (dr != null)
            {
                myForm.Invoke(deletextboxadd, dr.Messages.ToString());
            }
            else
            {
                myForm.Invoke(deletextboxadd, "下载不成功");
            }
            //pa.Download(mt, MyProject, np);
        }
        public void DownLoad()
        {
            NetParameter np = new NetParameter();
            //mt.Name = cpuName;
            np.Modes = "PN/IE";
            np.Number = 1;
            np.PcInterface = "Siemens PLCSIM Virtual Ethernet Adapter";
            np.TargetInterface = "1 X1";
            DownLoad(myCPU, np);
        }
        /// <summary>
        /// 在线连接PLC
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="np"></param>
        public void ConnectPLC(StationType mt, NetParameter np)
        {
            PLCAccess pa = new PLCAccess();
            pa.ConnectPLC(mt, MyProject, np);
        }
        /// <summary>
        /// 比较功能
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="np"></param>
        public void ComparePLC(StationType mt, NetParameter np)
        {
            PLCAccess pa = new PLCAccess();
            pa.ComparePlcToOnlinePlc(mt, MyProject, np);
        }
        /// <summary>
        /// 导入PLC变量
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="path"></param>
        public void PLCTagImport(StationType mt, FileInfo path)
        {
            XMLFunction.PLCTagImport(mt, MyProject, path);
        }
        /// <summary>
        /// 导出PLC变量
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="path"></param>
        public void PLCTagExport(StationType mt, FileInfo path)
        {
            XMLFunction.PLCTagExport(mt, MyProject, path);
        }

        //public void ImportGroup(PlcBlockGroup plcBG, DirectoryInfo[] dis, ProgressBar pb)
        //{
        //    XMLFunction.ImportGroup(plcBG, dis, pb);
        //}

        //public void ImportGroup(PlcBlockGroup plcBG, DirectoryInfo[] dis)
        //{
        //    XMLFunction.ImportGroup(plcBG, dis);
        //}

        //public void ImportGroup(PlcBlockGroup plcBG, Workshop ws, ProgressBar pb)
        //{
        //    XMLFunction.ImportGroup(plcBG, ws, pb);
        //}

        //public void ImportGroup(PlcBlockGroup plcBG, Workshop ws, DirectoryInfo[] dis, ProgressBar pb)
        //{
        //    XMLFunction.ImportGroup(plcBG, ws, dis, pb);
        //}
        public string AccessDrvPara()
        {
            //DriveObject driveobject = StationsFunction.GetDrvObject(MyProject);
            //DriveParameter parameter = driveobject.Parameters.Find("p5391[0]");
            //string namee = parameter.Name;
            //string value = parameter.Value.ToString();
            //object min = parameter.MinValue;
            //object max = parameter.MaxValue;
            //object unit = parameter.Unit;
            //parameter.Value = 60;


            return null;
        }
        //private delegate void UpDateTreeView();
        private delegate void deleTextBoxAdd(string st);

        //public void AddStationTotal()
        //{
        //    //myEM.GetData();
        //    myPB.Minimum = 0;
        //    myPB.Value = 0;
        //    myPB.Maximum = CountPrMax(myEM);
        //    //Moduletype mt = new Moduletype();
        //    deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
        //    try
        //    {
        //        //Add stations
        //        for (int i = 0; i < myEM.myDS.Tables.Count; i++)
        //        {
        //            StationType infa = new StationType();
        //            infa.Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
        //            infa.OderNo = myEM.myDS.Tables[i].Rows[1][1].ToString();
        //            infa.Version = myEM.myDS.Tables[i].Rows[1][3].ToString();
        //            infa.type = myEM.myDS.Tables[i].Rows[1][0].ToString();
        //            if (i == 0)
        //            {
        //                myCPU = infa;
        //            }

        //            //myFM.AddMasterModule(infa);
        //            //Add io modules
        //            for (int j = 2; j < myEM.myDS.Tables[i].Rows.Count; j++)
        //            {
        //                Moduletype mt = new Moduletype();
        //                string aa = myEM.myDS.Tables[i].Rows[j][0].ToString();
        //                mt.slotNo = Convert.ToInt32(aa);
        //                mt.OderNo = myEM.myDS.Tables[i].Rows[j][1].ToString();
        //                mt.Name = myEM.myDS.Tables[i].Rows[j][2].ToString();
        //                mt.Version = myEM.myDS.Tables[i].Rows[j][3].ToString();
        //                mt.type = myEM.myDS.Tables[i].Rows[j][0].ToString();
        //                infa.Modules.Add(mt);
        //                //myFM.AddStationModule(infa, mt);
        //                //progressBar1.Value++;
        //            }

        //            AddMasterModule(infa, myPB, myTB, myForm);

        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        StatusText = exp.Message;
        //    }
        //    if (SubNet == true)
        //    {
        //        try
        //        {
        //            string netname = myEM.myDS.Tables[0].Rows[1][4].ToString();
        //            StationType mt = new StationType();
        //            for (int i = 0; i < myEM.myDS.Tables.Count; i++)
        //            {
        //                mt.Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
        //                mt.IPAdress = myEM.myDS.Tables[i].Rows[1][5].ToString();
        //                mt.type = myEM.myDS.Tables[i].Rows[1][0].ToString();
        //                AddNet(netname, mt);
        //                myPB.Value++;
        //                myForm.Invoke(deletextboxadd, "站点" + mt.Name + "的子网已经添加");
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            StatusText = exp.Message;
        //        }

        //    }

        //    if (PNIO == true)
        //    {
        //        try
        //        {
        //            string iosysname = myEM.myDS.Tables[0].Rows[1][6].ToString();
        //            string netname = myEM.myDS.Tables[0].Rows[1][4].ToString();
        //            StationType mt = new StationType();
        //            for (int i = 0; i < myEM.myDS.Tables.Count; i++)
        //            {
        //                mt.Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
        //                mt.IPAdress = myEM.myDS.Tables[i].Rows[1][5].ToString();
        //                mt.type = myEM.myDS.Tables[i].Rows[1][0].ToString();
        //                AddIOSys(netname, iosysname, mt);
        //                myPB.Value++;
        //                myForm.Invoke(deletextboxadd, "站点 " + mt.Name + " 的PNIO系统已经添加");
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            StatusText = exp.Message;
        //        }
        //    }

        //    if (Topu == true)
        //    {
        //        try
        //        {
        //            StationType mt1 = new StationType();
        //            StationType mt2 = new StationType();
        //            for (int i = 0; i < myEM.myDS.Tables.Count - 1; i++)
        //            {
        //                mt1.Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
        //                mt1.ConPort = 0;
        //                mt1.type = myEM.myDS.Tables[i].Rows[1][0].ToString();
        //                mt2.Name = myEM.myDS.Tables[i + 1].Rows[1][2].ToString();
        //                mt2.ConPort = 1;
        //                mt2.type = myEM.myDS.Tables[i + 1].Rows[1][0].ToString();
        //                AddTopoCn(mt1, mt2);
        //                myPB.Value++;
        //                myForm.Invoke(deletextboxadd, "站点 " + mt1.Name + " 和" + mt2.Name + " 的拓扑连接已经添加");
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            StatusText = exp.Message;
        //        }
        //    }
        //    UpDateTreeView UDTV = new UpDateTreeView(dGetTreeView);
        //    myForm.Invoke(UDTV);
        //    //GetTreeView(myTV);
        //    //myTV.Invoke(updatetv);
        //    //PublicFunctions.UpdateTV updatetv = obj as PublicFunctions.UpdateTV;
        //    //this.Invoke(updatetv);
        //    //updatetv();
        //    //myTV.Invoke(updatetv);      

        //}
        //private void dGetTreeView()
        //{
        //    GetTreeView(myTV);
        //}
        private void TextBoxAdd(string st)
        {
            myTB.Text = myTB.Text + st + "\r\n";
        }
        //private int CountPrMax(ExcelManager em)
        //{
        //    int count = 0;
        //    try
        //    {
        //        for (int i = 0; i < em.myDS.Tables.Count; i++)
        //        {
        //            for (int j = 2; j < em.myDS.Tables[i].Rows.Count; j++)
        //            {
        //                count++;
        //            }
        //        }
        //        if (SubNet == true)
        //        {
        //            for (int i = 0; i < em.myDS.Tables.Count; i++)
        //            {
        //                count++;
        //            }
        //        }
        //        if (PNIO == true)
        //        {
        //            for (int i = 0; i < em.myDS.Tables.Count; i++)
        //            {
        //                count++;
        //            }
        //        }
        //        if (Topu == true)
        //        {
        //            for (int i = 0; i < em.myDS.Tables.Count - 1; i++)
        //            {
        //                count++;
        //            }
        //        }
        //        return count;
        //    }
        //    catch (Exception exp)
        //    {
        //        return 0;
        //    }
        //}

    }
}