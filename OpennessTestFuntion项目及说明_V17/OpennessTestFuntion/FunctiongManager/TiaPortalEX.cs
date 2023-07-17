using Siemens.Engineering;
using Siemens.Engineering.HW;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using FileManager;
using System.Windows.Forms;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW;
//using Siemens.Engineering.MC.Drives;
using Siemens.Engineering.Download;
using Siemens.Engineering.Upload;
using Siemens.Engineering.Online;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Download.Configurations;

using System.Security;
using Siemens.Engineering.Connection;
using Siemens.Engineering.Online.Configurations;
using Siemens.Engineering.Upload.Configurations;

namespace FunctionManager
{
    public class TiaPortalEX
    {
        public ProgressInformation MyprogressInformation = new ProgressInformation();
        private TiaPortal myTiaPortal;        
        private bool PortalUI = false;
        private ProjectEX myProjectEX = new ProjectEX();
        private static TiaPortalProcess tiaProcess;

        public string myDownloadResult;

        public UserGlobalLibrary myGlobalLibrary { get; set; }//博图类的全局库属性

        /// <summary>
        /// 启动Portal
        /// </summary>
        /// <returns></returns>
        public string Start()
        {
            if (PortalUI == true)
            {
                myTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);

                tiaProcess = TiaPortal.GetProcesses()[0];
                return "博途已经启动";
            }
            else
            {
                myTiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);
                //new TiaPortal(TiaPortalMode.WithUserInterface);
                return "博途已经启动";
            }
        }
        /// <summary>
        /// 创建一个项目
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string CreatProject(string path, string name)
        {
            //myProjectEX = new ProjectEX();
            myProjectEX.myTiaPortal = this.myTiaPortal;
            return myProjectEX.Creat(path, name);
        }
        public string OpenProject()
        {
            // myProjectEX.myTiaPortal = this.myTiaPortal;
            return "null";
            //return myProjectEX.OpenProject();
        }
        public string ConnectTiaPortal()
        {
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            switch (processes.Count)
            {
                case 1:
                    tiaProcess = processes[0];
                    myTiaPortal = tiaProcess.Attach();
                    //if (myTiaPortal.GetCurrentProcess().Mode == TiaPortalMode.WithUserInterface)
                    //{
                    //    //rdb_WithUI.Checked = true;
                    //    //return "";                      
                    //}
                    //else
                    //{
                    //    //rdb_WithoutUI.Checked = true;
                    //    //return "";
                    //}
                    if (myTiaPortal.Projects.Count <= 0)
                    {
                        return "没有博途项目";
                    }
                    else
                    {
                        //myProjectEX = myTiaPortal.Projects[0];
                        myProjectEX.myTiaPortal = this.myTiaPortal;
                        return myProjectEX.ConnectProject();
                    }
                //break;
                case 0:
                    return "没有运行的博途实例";

                default:
                    return "运行的实例个数超过1个";

            }

            //return null;
        }
        private Device GetCPUDeviceFormDevices()
        {
            Project m_Project = myTiaPortal.Projects[0]; //获取Portal中的项目

            foreach (Device device in m_Project.Devices)
            {
                //string aa = device.TypeIdentifier;
                if (device.TypeIdentifier == "System:Device.S71500" || device.TypeIdentifier == "System:Device.S71200")
                {
                    return device;
                }
            }
            foreach (DeviceUserGroup dug in m_Project.DeviceGroups)
            {
                foreach (Device device in dug.Devices)
                {
                    if (device.TypeIdentifier == "System:Device.S71500" || device.TypeIdentifier == "System:Device.S71200")
                    {
                        return device;
                    }
                }
            }
            return null;
        }
        public ProjectEX GetProjectEX()//获取Portal中的项目对象
        {
            return myProjectEX;
        }
        public string ImportGlobalLibrary(FileInfo path)//导入全局库，获取全局库变量
        {
            if (myTiaPortal != null)
            {
                try
                {
                    myGlobalLibrary = myTiaPortal.GlobalLibraries.Open(path, OpenMode.ReadWrite);
                    return "全局库成功导入";
                }
                catch (Exception exp)
                {
                    //MyprogressInformation.TextBoxAdd("没有打开或者连接博途项目,没有正确设置库路径");
                    return "没有正确设置库路径";
                }
            }
            else
            {
                return "没有打开或者连接博途项目";
            }
        }

        //拷贝全局库主模板到项目库主模板
        public string CopyMasterCopies()
        {
            if (myGlobalLibrary != null)
            {
                try
                {
                    myProjectEX.DeleteMasterCopiesFromProjecLib();//删除项目库中所有主模板
                    foreach (MasterCopy mc in myGlobalLibrary.MasterCopyFolder.MasterCopies)
                    {
                        myProjectEX.myProject.ProjectLibrary.MasterCopyFolder.MasterCopies.CreateFrom(mc);
                    }
                }
                catch(Exception exp)
                {
                    return "没有正确设置库路径";
                }
                return "";
            }
            return "没有正确打开全局库";
        }

        public string CloseLibrary()//关闭全局库
        {
            if (myGlobalLibrary != null)
            {
                myGlobalLibrary.Close();
                return "关闭成功";
            }
            return null;
        }


        public void InitializeEvent()
        {
            myTiaPortal.Disposed += OnDisposed;
        }


        private void OnDisposed(object sender, EventArgs e)
        {
            MyprogressInformation.TextBoxAdd("\r\n" + "博途已经关闭");
        }
        private static void PreConfigureDownload(DownloadConfiguration downloadConfiguration)
        {

            // = downloadConfiguration as ResetModule;
            ResetModule resetModule = downloadConfiguration as ResetModule;
            if (resetModule != null)
            {
                resetModule.CurrentSelection = ResetModuleSelections.NoAction;
                return;
            }

            StopModules stopModules = downloadConfiguration as StopModules;
            
            if (stopModules != null)

            {
                
                stopModules.CurrentSelection = StopModulesSelections.StopAll; // This selection will set PLC into "Stop" mode 

                return;

            }

            AlarmTextLibrariesDownload alarmTextLibraries = downloadConfiguration as AlarmTextLibrariesDownload;

            if (alarmTextLibraries != null)

            {

                alarmTextLibraries.CurrentSelection = AlarmTextLibrariesDownloadSelections.ConsistentDownload;

                return;

            }

            BlockBindingPassword blockBindingPassword = downloadConfiguration as BlockBindingPassword;

            if (blockBindingPassword != null)

            {

               // SecureString password = ...;// Get Binding password from a secure location 

               // blockBindingPassword.SetPassword(password);

                return;

            }

            CheckBeforeDownload checkBeforeDownload = downloadConfiguration as CheckBeforeDownload;

            if (checkBeforeDownload != null)

            {

                checkBeforeDownload.Checked = true;

                return;

            }

            ConsistentBlocksDownload consistentBlocksDownload = downloadConfiguration as ConsistentBlocksDownload;

            if (consistentBlocksDownload != null)

            {

                consistentBlocksDownload.CurrentSelection = ConsistentBlocksDownloadSelections.ConsistentDownload;

                return;

            }

            Siemens.Engineering.Download.Configurations.ModuleWriteAccessPassword moduleWriteAccessPassword = downloadConfiguration as Siemens.Engineering.Download.Configurations.ModuleWriteAccessPassword;

            if (moduleWriteAccessPassword != null)

            {

               // SecureString password = ...;// Get PLC protection level password from a secure location 

               // moduleWriteAccessPassword.SetPassword(password);

                return;

            }
            ProtectionLevelChanged protectionLevelChanged = downloadConfiguration as ProtectionLevelChanged;
            if (protectionLevelChanged != null)
            {
                protectionLevelChanged.CurrentSelection = ProtectionLevelChangedSelections.ContinueDownloading;
                return;
            }

            OverwriteSystemData overwriteSystemData = downloadConfiguration as OverwriteSystemData;
            if(overwriteSystemData != null)
            {
                overwriteSystemData.CurrentSelection = OverwriteSystemDataSelections.Overwrite;
                return;
            }

            //throw new NotSupportedException(); // Exception thrown in the delagate will cancel download 



            /*////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////
            StopModules stopModules = downloadConfiguration as StopModules;
            if (stopModules != null)
            {
                stopModules.CurrentSelection = StopModulesSelections.StopAll;  // This selection will set PLC into "Stop" mode
                return;
            }
            ProtectionLevelChanged protectionLevelChanged = downloadConfiguration as ProtectionLevelChanged;
            if(protectionLevelChanged!=null)
            {
                protectionLevelChanged.CurrentSelection = ProtectionLevelChangedSelections.ContinueDownloading;
            }
            AlarmTextLibrariesDownload alarmTextLibraries = downloadConfiguration as AlarmTextLibrariesDownload;
            if (alarmTextLibraries != null)
            {
                alarmTextLibraries.CurrentSelection = AlarmTextLibrariesDownloadSelections.ConsistentDownload;
                return;
            }
            BlockBindingPassword blockBindingPassword = downloadConfiguration as BlockBindingPassword;
            if (blockBindingPassword != null)
            {
                SecureString password = new SecureString();  // Get Binding password from a secure location
                string pa = "123456";
                foreach (char c in pa)
                {
                    password.AppendChar(c);
                }
                blockBindingPassword.SetPassword(password);
                return;
            }
            CheckBeforeDownload checkBeforeDownload = downloadConfiguration as CheckBeforeDownload;
            if (checkBeforeDownload != null)
            {
                checkBeforeDownload.Checked = true;
                return;
            }
            ConsistentBlocksDownload consistentBlocksDownload = downloadConfiguration as ConsistentBlocksDownload;
            if (consistentBlocksDownload != null)
            {
                consistentBlocksDownload.CurrentSelection = ConsistentBlocksDownloadSelections.ConsistentDownload;
                return;
            }
            ModuleWriteAccessPassword moduleWriteAccessPassword = downloadConfiguration as ModuleWriteAccessPassword;
            if (moduleWriteAccessPassword != null)
            {
                SecureString password = new SecureString();  // Get PLC protection level password from a secure location
                string pa = "123456";
                foreach (char c in pa)
                {
                    password.AppendChar(c);
                }
                moduleWriteAccessPassword.SetPassword(password);
                return;
            }*/
            //throw new NotSupportedException();  // Exception thrown in the delagate will cancel download
        }

        private static void PostConfigureDownload(DownloadConfiguration downloadConfiguration)
        {
            StartModules startModules = downloadConfiguration as StartModules;
            if (startModules != null)
            {
                startModules.CurrentSelection = StartModulesSelections.StartModule; // Sets PLC in "Run" mode 
            }
        }

        private void Configuration_OnlineLegitimation(OnlineConfiguration onlineConfiguration)
        {
           /* TlsVerificationConfiguration verificationConfiguration = onlineConfiguration as TlsVerificationConfiguration;
            if (verificationConfiguration != null)
            {
                verificationConfiguration.CurrentSelection = TlsVerificationConfigurationSelection.Trusted;
                //To establish a connection the value Trusted is necessary.
            }*/
        }

        public void Download(int selectionOption, ComboBox adapter,TextBox ipAddress, ComboBox netInterface)
        {
            Device device = GetCPUDeviceFormDevices();
            DownloadConfigurationDelegate preDownloadDelegate = PreConfigureDownload;
            DownloadConfigurationDelegate postDownloadDelegate = PostConfigureDownload;
            //OnlineConfigurationDelegate m_OnlineConfigurationDelegate = OnlineCallBackMethod;

            if (device != null)
            {
                var downloadProvider = device.DeviceItems[1].GetService<DownloadProvider>();
                //downloadProvider.Configuration.OnlineLegitimation += OnlineCallBackMethod;
                var onlineProvider = device.DeviceItems[1].GetService<OnlineProvider>();
               
                //onlineProvider.Configuration.OnlineLegitimation += m_OnlineConfigurationDelegate;

                if (downloadProvider != null)
                {
                    ConnectionConfiguration configuration = downloadProvider.Configuration;
                    configuration.EnableLegacyCommunication = true;
                    //onlineProvider.Configuration.EnableLegacyCommunication =true;
                    ConfigurationMode configurationMode = configuration.Modes.Find("PN/IE");
                    //ConfigurationPcInterface pcInterface1 = configurationMode.PcInterfaces[0];
                    // ConfigurationPcInterface pcInterface2 = configurationMode.PcInterfaces[1];
                    //ConfigurationPcInterface pcInterface3 = configurationMode.PcInterfaces[2];
                    //选择网卡
                    string strAdapter = adapter.SelectedItem.ToString();
                    ConfigurationPcInterface pcInterface = configurationMode.PcInterfaces.Find(strAdapter, 1);
                    //选择端口
                    int interfaceIndex;
                    if(netInterface.Items.Count == 0 )
                    {
                        interfaceIndex = 0;
                    }
                    else
                    {
                        interfaceIndex = netInterface.SelectedIndex;
                    }
                    IConfiguration targetConfiguration = pcInterface.TargetInterfaces[interfaceIndex];

                    ConfigurationTargetInterface targetConfigurationIF = targetConfiguration as ConfigurationTargetInterface;
                    ConfigurationAddressComposition downloadAddresses = targetConfigurationIF.Addresses;
                    ConfigurationAddress onlineAddress = downloadAddresses.Create(ipAddress.Text);
                    DownloadResult downloadResult = null;
                    //选择下载方式
                   //downloadProvider.Configuration.OnlineLegitimation += Configuration_OnlineLegitimation;
                   // OnlineConfigurationDelegate m_OnlineConfigurationDelegate = OnlineCallBackMethod;
                    //downloadProvider.Configuration.OnlineLegitimation += m_OnlineConfigurationDelegate;
                    switch (selectionOption)
                    {
                        case 0:
                            downloadResult = downloadProvider.Download(targetConfiguration, onlineAddress, preDownloadDelegate,
                           postDownloadDelegate, DownloadOptions.Hardware); break;
                        case 1:
                            downloadResult = downloadProvider.Download(targetConfiguration, onlineAddress, preDownloadDelegate,
                       postDownloadDelegate, DownloadOptions.Software); break;
                        case 2:
                            downloadResult = downloadProvider.Download(targetConfiguration, onlineAddress, preDownloadDelegate,
                       postDownloadDelegate, DownloadOptions.Hardware | DownloadOptions.Software); break;
                        case 3:
                            downloadResult = downloadProvider.Download(targetConfiguration, onlineAddress, preDownloadDelegate,
                       postDownloadDelegate, DownloadOptions.SoftwareOnlyChanges); break;
                        case 4:
                            downloadResult = downloadProvider.Download(targetConfiguration, onlineAddress, preDownloadDelegate,
                       postDownloadDelegate, DownloadOptions.Hardware | DownloadOptions.SoftwareOnlyChanges); break;

                    }
                    // downloadOptions = DownloadOptions.Hardware;

                    myDownloadResult = downloadResult.State.ToString();

                    /*try
                    {
                        //downloadResult = downloadProvider.Download(targetConfiguration,onlineAddress, preDownloadDelegate,
                          //     postDownloadDelegate, DownloadOptions.Hardware | DownloadOptions.Software);
                    }
                    catch (Exception exp)
                    {
                        ;
                        //return null;
                    }*/

                }
            }
        }

        private void PreConfigureUpload(UploadConfiguration uploadConfiguration)
        {

        }
        public void UpLoad(ComboBox adapter, TextBox ipAddress)
        {            
            Project m_Project = myTiaPortal.Projects[0]; //获取Portal中的项目
            StationUploadProvider stationUploadProvider = m_Project.GetService<StationUploadProvider>();
            if(stationUploadProvider != null)
            {
                ConnectionConfiguration connectionConfiguration = stationUploadProvider.Configuration;
                ConfigurationMode configurationMode = connectionConfiguration.Modes.Find("PN/IE");
                //string strAdapter = adapter.SelectedItem.ToString();
                ConfigurationPcInterface configurationPcInterface = configurationMode.PcInterfaces.Find("Siemens PLCSIM Virtual Ethernet Adapter", 1);
                ConfigurationAddress configurationAddress = configurationPcInterface.Addresses.Create(ipAddress.Text);
                stationUploadProvider.StationUpload(configurationAddress, PreConfigureUpload);
            }
        }

        public void GetNetAdapterName(ComboBox adapter)
        {
            Device device = GetCPUDeviceFormDevices();
            if (device != null)
            {
                DownloadProvider downloadProvider = device.DeviceItems[1].GetService<DownloadProvider>();
                if (downloadProvider != null)
                {
                    ConnectionConfiguration configuration = downloadProvider.Configuration;
                    ConfigurationMode configurationMode = configuration.Modes.Find("PN/IE");
                    for (int i = 0; i < configurationMode.PcInterfaces.Count; i++)
                    {
                        adapter.Items.Add(configurationMode.PcInterfaces[i].Name.ToString());
                    }
                }
            }

        }

        public void GetInterface(ComboBox adapter ,ComboBox netInterface)
        {
            Device device = GetCPUDeviceFormDevices();
            if (device != null)
            {
                DownloadProvider downloadProvider = device.DeviceItems[1].GetService<DownloadProvider>();
                if (downloadProvider != null)
                {
                    ConnectionConfiguration configuration = downloadProvider.Configuration;
                    ConfigurationMode configurationMode = configuration.Modes.Find("PN/IE");
                    string strAdapter = adapter.SelectedItem.ToString();
                    ConfigurationPcInterface pcInterface = configurationMode.PcInterfaces.Find(strAdapter, 1);
                    netInterface.Items.Clear();
                    for (int i = 0; i < pcInterface.TargetInterfaces.Count; i++)
                    {
                        netInterface.Items.Add(pcInterface.TargetInterfaces[i].Name.ToString());
                    }                    
                }
            }
        }

                


    }
    public class ProjectEX
    {
        public Project myProject { get; set; }
        public ProgressInformation MyprogressInformation { get; set; }
        public TiaPortal myTiaPortal { get; set; }
        public string Creat(string path, string name)
        {
            try
            {
                if (myTiaPortal.Projects.Count <= 0)
                {

                    ProjectComposition projectComposition = myTiaPortal.Projects;
                    DirectoryInfo targetDirectory = new DirectoryInfo(path);
                    myProject = projectComposition.Create(targetDirectory, name);
                    return "项目正常创建";
                }
                else
                {
                    return "项目已经创建";
                }
            }
            catch (Exception e)
            {
                return "指定项目路径无效";
            }

        }

        private ExcelManager myEM ;
        public ProgressBar myProgressBar { get; set; }
        public TreeView myTreeView { get; set; }
        public Form myForm { get; set; }
        public bool SubNet { get; set; }
        public bool PNIO { get; set; }
        public bool Topu { get; set; }
        public TextBox myTextBox { get; set; }//输出添加信息
        public StationType myCPU { get; set; }//CPU模块信息
        public string ExcelFilePath { get; set; }//存放硬件信息的Excel文件路径
        //删除项目库中所有的主拷贝
        public string DeleteMasterCopiesFromProjecLib()
        {
            MasterCopy masterCopy = myProject.ProjectLibrary.MasterCopyFolder.MasterCopies.FirstOrDefault();
            while (masterCopy != null)
            {
                masterCopy.Delete();
                masterCopy = myProject.ProjectLibrary.MasterCopyFolder.MasterCopies.FirstOrDefault();
            }
            return "";
        }
        //根据项目库中的HMI设备创建项目中的HMI设备实例
        public string CreateDeFormMasterCopies(string Name)
        {
            foreach (MasterCopy mc in myProject.ProjectLibrary.MasterCopyFolder.MasterCopies)
            {
                if (mc.Name == Name)
                {
                    myProject.Devices.CreateFrom(mc);
                }              
            }
            return "";
        }

        //private delegate void deleExcelCountMax();//定义代理
        private delegate void deleUpDateTreeView();//定义代理

        private Subnet mySubNet; // 项目中的子网系统
        private IoSystem ioSystem; //项目中的PNIO系统
        public List<StationType> myStations { get; set; } = new List<StationType>();//项目中的站点

        public StationType GetStation(string StationName)//根据站点名称获取站点
        {
            foreach (StationType station in myStations)
            {
                if (station.DeviceName == StationName)
                {
                    return station;
                }
            }
            return null;
        }

        public StationType GetStation()
        {
            try
            {
                foreach (StationType station in myStations)
                {
                    if (station.myDevice.TypeIdentifier == "System:Device.S71500" || station.myDevice.TypeIdentifier == "System:Device.S71200")
                    {
                        return station;
                    }
                }
            }
            catch (Exception exp)
            {

            }
            return null;
        }


        public string ConnectProject()
        {
            myProject = myTiaPortal.Projects[0];//获取Portal中的项目对象
            CollectStations();//收集项目中的硬件信息，放入myHardWare对象中
            return "项目已经连接";
        }
        public void AddHardWare()
        {
            myEM = new ExcelManager();
            
            deleUpDateTreeView updateTreeView = new deleUpDateTreeView(GetTreeView);
            myEM.GetData(ExcelFilePath);
            
            int ModuleCount = myEM.CountMax(SubNet, PNIO, Topu);//统计项目中所有对象的个数
            if (ModuleCount >= 2)
            {
                MyprogressInformation.CountProgressBar(ModuleCount - 2);//初始化ProgressBar
                MyprogressInformation.ClearTextBox();//初始化TextBox

                while (myStations.Count > 0)//清空站点
                {
                    myStations.RemoveAt(0);
                }

                AddStation();
                if (SubNet)
                {
                    AddSubNet();
                }
                if (PNIO)
                {
                    AddPNIO();
                }
                if (Topu)
                {
                    AddTopu();
                }
                myForm.Invoke(updateTreeView);
            }
            else
            {
                MyprogressInformation.TextBoxAdd("没有正确读取Excel文件");
                // myTextBox.Text = "没有正确读取Excel文件";
            }

        }
        private string AddStation()//添加站点
        {           
            //StationsFunction.deleTextBoxAdd deletextboxadd = new StationsFunction.deleTextBoxAdd(TextBoxAdd);
            try
            {
                //添加站点
                for (int i = 0; i < myEM.myDS.Tables.Count; i++)
                {
                    StationType station = new StationType();
                    station.Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
                    station.OderNo = myEM.myDS.Tables[i].Rows[1][1].ToString();
                    station.Version = myEM.myDS.Tables[i].Rows[1][3].ToString();
                    station.type = myEM.myDS.Tables[i].Rows[1][0].ToString();
                    station.myProject = myProject;//把项目对象传入StationType对象
                    station.MyprogressInformation = MyprogressInformation;
                    if (i == 0)
                    {
                        myCPU = station;
                    }
                    for (int j = 2; j < myEM.myDS.Tables[i].Rows.Count; j++)
                    {
                        Moduletype mt = new Moduletype();
                        string aa = myEM.myDS.Tables[i].Rows[j][0].ToString();
                        mt.slotNo = Convert.ToInt32(aa);
                        mt.OderNo = myEM.myDS.Tables[i].Rows[j][1].ToString();
                        mt.Name = myEM.myDS.Tables[i].Rows[j][2].ToString();
                        mt.Version = myEM.myDS.Tables[i].Rows[j][3].ToString();
                        mt.type = myEM.myDS.Tables[i].Rows[j][0].ToString();
                        station.Modules.Add(mt);//模块加入到模块组中
                    }

                    //AddMasterModule(infa, myProgressBar, myTextBox, myForm);
                    //infa.AddModule();
                    myStations.Add(station);//站点加入到站点组当中
                    station.AddModule();//为站点添加模块
                }
                return "添加完成";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }

        }
        private string AddSubNet()//添加子网
        {
            mySubNet = null;
            //StationsFunction.deleTextBoxAdd deletextboxadd = new StationsFunction.deleTextBoxAdd(StationsFunction.TextBoxAdd);
            //StationsFunction.deleProgressBarAdd delePBAdd = new StationsFunction.deleProgressBarAdd(StationsFunction.ProgressBarAdd);
            try
            {
                string netname = myEM.myDS.Tables[0].Rows[1][4].ToString();
                //MasterType mt = new MasterType();
                string SubNetMessage = CreatSubNet(netname);
                MyprogressInformation.TextBoxAdd(SubNetMessage);
                //myForm.Invoke(deletextboxadd, myTextBox, SubNetMessage);
                if(mySubNet==null)
                {
                    SubNetMessage = GetSubNet(netname);
                }
                //myForm.Invoke(deletextboxadd, myTextBox, SubNetMessage);
                MyprogressInformation.TextBoxAdd(SubNetMessage);

                for (int i = 0; i < myEM.myDS.Tables.Count; i++)
                {
                    myStations[i].Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
                    myStations[i].IPAdress = myEM.myDS.Tables[i].Rows[1][5].ToString();
                    myStations[i].type = myEM.myDS.Tables[i].Rows[1][0].ToString();
                    //AddNet(netname, myStations[i]);
                    //myProgressBar.Value++;
                    myStations[i].AddToSubNet(mySubNet);
                    //myForm.Invoke(delePBAdd, myProgressBar);
                    //myForm.Invoke(deletextboxadd,myTextBox, "站点" + myStations[i].Name + "的子网已经添加");                    
                }
                return "子网成功添加";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
            //return null;
        }
        private string AddPNIO()//添加PNIO系统
        {
            //StationsFunction.deleTextBoxAdd deletextboxadd = new StationsFunction.deleTextBoxAdd(StationsFunction.TextBoxAdd);
            //StationsFunction.deleProgressBarAdd delePBAdd = new StationsFunction.deleProgressBarAdd(StationsFunction.ProgressBarAdd);
            try
            {
                string iosysname = myEM.myDS.Tables[0].Rows[1][6].ToString();
                //MasterType mt = new MasterType();
                myStations[0].Name = myEM.myDS.Tables[0].Rows[1][2].ToString();//定位CPU名称
                CreatIOSys(iosysname, myStations[0]);//创建PNIO系统

                for (int i = 0; i < myEM.myDS.Tables.Count; i++)
                {
                    myStations[i].Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
                    myStations[i].IPAdress = myEM.myDS.Tables[i].Rows[1][5].ToString();
                    myStations[i].type = myEM.myDS.Tables[i].Rows[1][0].ToString();
                    ioSystem = mySubNet.IoSystems[0];
                    myStations[i].AddToIOSys(ioSystem);
                    //AddIOSys(iosysname, myStations[i]);
                    //myProgressBar.Value++;
                    //myForm.Invoke(delePBAdd, myProgressBar);
                    //myForm.Invoke(deletextboxadd, myTextBox, "站点 " + myStations[i].Name + " 的PNIO系统已经添加");
                }
                return "成功添加";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }
        private string AddTopu()
        {
            //StationsFunction.deleTextBoxAdd deletextboxadd = new StationsFunction.deleTextBoxAdd(StationsFunction.TextBoxAdd);
            //StationsFunction.deleProgressBarAdd delePBAdd = new StationsFunction.deleProgressBarAdd(StationsFunction.ProgressBarAdd);
            try
            {
                //MasterType mt1 = new MasterType();
                //MasterType mt2 = new MasterType();
                for (int i = 0; i < myEM.myDS.Tables.Count - 1; i++)
                {
                    myStations[i].Name = myEM.myDS.Tables[i].Rows[1][2].ToString();
                    myStations[i].ConPort = 0;
                    myStations[i].type = myEM.myDS.Tables[i].Rows[1][0].ToString();
                    myStations[i+1].Name = myEM.myDS.Tables[i + 1].Rows[1][2].ToString();
                    myStations[i+1].ConPort = 1;
                    myStations[i+1].type = myEM.myDS.Tables[i + 1].Rows[1][0].ToString();
                    AddTopoCn(myStations[i], myStations[i+1]);
                    //myProgressBar.Value++;
                    //myForm.Invoke(delePBAdd, myProgressBar);
                    //myForm.Invoke(deletextboxadd, myTextBox, "站点 " + myStations[i].Name + " 和" + myStations[i+1].Name + " 的拓扑连接已经添加");
                }
                return "成功建立";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        //private string AddMasterModule(StationType infa, ProgressBar pb, TextBox tb, Form fm)
        //{
        //    if ((infa.type == "G") || (infa.type == "S"))
        //    {
        //        return StationsFunction.AddDrvMasterModule(infa, myProject, pb, tb, fm);
        //    }
        //    else
        //    {
        //        return StationsFunction.AddMasterModule(infa, myProject, pb, tb, fm);
        //    }

        //}
        private bool JudgeInterface(string ifName)
        {
            bool flag = false;
            bool Flag = false;
            List<string> interfaces = new List<string>();
            interfaces.Add("PROFINET 接口_1");
            interfaces.Add("PROFINET 接口");
            interfaces.Add("PROFINET interface_1");
            interfaces.Add("PROFINET interface");
            foreach (string st in interfaces)
            {
                if (ifName == st)
                {
                    flag = true;
                }
                Flag = Flag || flag;
            }
            return Flag;
        }
        //private string AddNet(string netname, StationType mt)
        //{          
        //    NetworkInterface networkInterface = null;           
        //    string devname = "station" + mt.Name;

        //    try
        //    {
        //        if (mt.type == "G")
        //        {
        //            foreach (DeviceItem deviceItem in myProject.Devices.Find("SINAMICS G_1").DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    mt.networkInterface = networkInterface;
        //                    networkInterface.Nodes.First().SetAttribute("Address", mt.IPAdress);
        //                    try
        //                    {
        //                        networkInterface.Nodes.First().ConnectToSubnet(mySubNet);
        //                        return "成功连接";
        //                    }
        //                    catch (Exception exp)
        //                    {
        //                        return exp.Message;
        //                    }
        //                }
        //            }

        //        }
        //        else
        //        {
        //            foreach (DeviceItem deviceItem in myProject.Devices.Find(devname).DeviceItems[1].DeviceItems)
        //            {
        //                if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
        //                {
        //                    networkInterface = deviceItem.GetService<NetworkInterface>();
        //                    mt.networkInterface = networkInterface;
        //                    networkInterface.Nodes.First().SetAttribute("Address", mt.IPAdress);
        //                    try
        //                    {
        //                        networkInterface.Nodes.First().ConnectToSubnet(mySubNet);
        //                        return "成功连接";
        //                    }
        //                    catch (Exception exp)
        //                    {
        //                        return exp.Message;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message; ;
        //    }
        //    return null;
        //}
        //private string AddIOSys(string IOname, StationType mt)
        //{           
        //    NetworkInterface networkInterface = mt.networkInterface;            
        //    IoSystem _ioSystem = mySubNet.IoSystems[0];

        //    try
        //    {
        //        networkInterface.IoConnectors.First().ConnectToIoSystem(_ioSystem);
        //    }    
     
        //    catch (Exception exp)
        //    {
        //        return exp.Message;
        //    }

        //    return "成功添加";
        //}
        private string AddTopoCn(StationType mt1, StationType mt2)
        {
            NetworkPort port1 = null;
            NetworkPort port2 = null;         

            try
            {
                port1 = mt1.networkInterface.Ports[mt1.ConPort];
                port2 = mt2.networkInterface.Ports[mt2.ConPort];
                port1.ConnectToPort(port2);
                MyprogressInformation.ProgressBarAdd();
                MyprogressInformation.TextBoxAdd("站点 " + mt1.Name + " 和" + mt2.Name + " 的拓扑连接已经添加");
            }      
            catch (Exception exp)
            {
                //return exp.Message;
                return "";
            }

            return "添加成功 ";
        }
        //private void CountMax()
        //{
        //    myProgressBar.Maximum = myEM.CountMax(SubNet, PNIO, Topu);
        //}
        private string CreatSubNet(string SubNetName)
        {
            try
            {
                mySubNet = myProject.Subnets.Create("System:Subnet.Ethernet", SubNetName);
                //myHardWare.mySubNet = myProject.Subnets.Create("System:Subnet.Ethernet", SubNetName);
                return "子网" + SubNetName + "成功建立";
            }
            catch (Exception exp)
            {
                //return exp.Message + "\r\n" +"存在同名子网,创建失败";
                return "";
            }
        }
        private string GetSubNet(string SubNetName)
        {
            try
            {
                mySubNet = myProject.Subnets.Find(SubNetName);
                //myHardWare.mySubNet = myProject.Subnets.Find(SubNetName);
                return "子网" + SubNetName + "成功获取";
            }
            catch (Exception exp)
            {
                //return exp.Message + "\r\n" + "获取失败";
                return "";
            }
        }
        private string CreatIOSys(string IOSysName, StationType mt)
        {
            NetworkInterface networkInterface = null;
            IoSystem ioSystem = null;           
            string devname = "station" + mt.Name;
            try
            {
                foreach (DeviceItem deviceItem in myProject.Devices.Find(devname).DeviceItems[1].DeviceItems)
                {
                    if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1"|| deviceItem.Name == "PROFINET 接口")
                    {
                        networkInterface = deviceItem.GetService<NetworkInterface>();
                        if ((networkInterface.InterfaceOperatingMode & InterfaceOperatingModes.IoController) != 0)
                        {
                            IoController ioController = networkInterface.IoControllers.First();
                            if (ioController != null)
                            {
                                ioSystem = ioController.CreateIoSystem(IOSysName);                                
                            }
                        }
                    }
                }
                return "IO系统成功创建";
            }
            catch (Exception exp)
            {
                //return exp.Message;
                return "";
            }

        }
        private string CollectStations()
        {
            while (myStations.Count > 0)
            {
                myStations.RemoveAt(0);
            }

            foreach (Device device in myProject.Devices)
            {
                StationType station = new StationType();
                station.myDevice = device;
                station.DeviceName = device.Name;
                myStations.Add(station);
            }
            foreach (DeviceUserGroup dug in myProject.DeviceGroups)
            {                
                foreach (Device device in dug.Devices)
                {
                    StationType station = new StationType();
                    station.myDevice = device;
                    station.DeviceName = device.Name;
                    myStations.Add(station);
                }
            }
            return "硬件收集成功";
        }

        private void GetTree(TreeNode tn, DeviceItem di)
        {
            //TreeNode node = new TreeNode(di.Name);
            //TreeNode sutn = tn
            TreeNode sutn = tn.Nodes.Add(di.Name);
            foreach (DeviceItem deitem in di.DeviceItems)
            {
                GetTree(sutn, deitem);
            }
        }
        private void GetTreeView()
        {
            try
            {

                if (myProject != null)
                {
                    Project project = myProject;
                    myTreeView.Nodes.Clear();
                    foreach (Device device in project.Devices)
                    {
                        TreeNode tn1 = myTreeView.Nodes.Add(device.Name);

                        foreach (DeviceItem deitem in device.DeviceItems)
                        {
                            GetTree(tn1, deitem);
                        }
                    }
                    foreach (DeviceUserGroup dug in project.DeviceGroups)
                    {
                        TreeNode tn = myTreeView.Nodes.Add(dug.Name);
                        foreach (Device device in dug.Devices)
                        {
                            TreeNode tn1 = tn.Nodes.Add(device.Name);
                            foreach (DeviceItem deitem in device.DeviceItems)
                            {
                                GetTree(tn1, deitem);
                            }
                        }
                    }
                }
                else
                {
                    MyprogressInformation.TextBoxAdd("没有打开或连接博途项目");
                }
            }
            catch (Exception exp)
            {
                MyprogressInformation.TextBoxAdd("没有打开或连接博途项目");
            }
        }

    }
    
}
