using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using Siemens.Engineering;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
//using Siemens.Engineering.MC.Drives;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.Compiler;
using FileManager;

namespace FunctionManager
{
    public class UnitType
    {
        public string Name { get; set; }
        public string OderNo { get; set; }
        public string Version { get; set; }
    }

    public class StationType : UnitType
    {
        public ProgressInformation MyprogressInformation { get; set; }
        public Project myProject { get; set; }//说明这个Station属于哪个Project
        public string IPAdress { get; set; }
        public int ConPort { get; set; }
        public string DeviceName { get; set; }
        public bool OnLineFlag { get; set; }
        public string type { get; set; }
        public NetworkInterface networkInterface { get; set; }                
        //public PlcSoftware mySoftware { get; set; }
        public Device myDevice { get; set; }
        public List<Moduletype> Modules { get; set; } = new List<Moduletype>();

        private delegate Device deleCreateWithItem(string MLFB, string name, string devname);
        

        public void DeleteAllBlocks()
        {
            PlcSoftware software = GetSoftware();
            for(int i= software.BlockGroup.Groups.Count-1;i>=0;i--)
            {
                PlcBlockUserGroup group = software.BlockGroup.Groups[i];
                if (group != null)
                {
                    string name = group.Name;
                    group.Delete();
                    try
                    {
                        MyprogressInformation.TextBoxAdd(name + " 成功删除");
                    }
                    catch (Exception exp)
                    {
                        ;
                    }
                }
            }           

            //  or BlockUserGroup group = ...;
            for (int i = software.BlockGroup.Blocks.Count - 1; i >= 0; i--)
            {
                PlcBlock block = software.BlockGroup.Blocks[i];
                if (block != null)
                {
                    string name = block.Name;
                    block.Delete();
                    try
                    {
                        MyprogressInformation.TextBoxAdd(name + " 成功删除");
                    }
                    catch (Exception exp)
                    {
                        ;
                    }
                }
            }            
        }

        public string AddModule()//添加模块
        {
            if ((type == "G") || (type == "S"))
            {
                return AddDrvModule();
            }
            else
            {
                return AddPLCModule();
            }

        }

        private string AddPLCModule()//添加PLC模块
        {
            Device device = null;
            string MLFB = "OrderNumber:" + OderNo + "/" + Version;
            string name = Name;
            string devname = "station" + Name;

            
            try
            {
                deleCreateWithItem CreateWithItem = new deleCreateWithItem(myProject.Devices.CreateWithItem);
                //MyprogressInformation.Myform.Invoke(CreateWithItem, MLFB, name, devname);
                device = (Device)MyprogressInformation.Myform.Invoke(CreateWithItem, MLFB, name, devname);
                myDevice = device;
                DeviceName = device.Name;
                //return "添加成功";
                //return StatusText;
                //fm.Invoke(deletextboxadd, tb, "模块 " + im.OderNo + " 已经添加");
                MyprogressInformation.ProgressBarAdd();
                MyprogressInformation.TextBoxAdd("模块 " + OderNo + " 已经添加");
            }
            catch (Exception e)
            {
                return e.Message;
            }

            if (device != null)
            {
                //string sssss = device.Name;
                foreach (Moduletype module in Modules)
                {
                    foreach (DeviceItem deviceItem in device.DeviceItems)
                    {
                        string devMLFB = "OrderNumber:" + module.OderNo + "/" + module.Version;
                        if (deviceItem.Container.CanPlugNew(devMLFB, module.Name, module.slotNo))
                        {
                            DeviceItem newPluggedDeviceItem = deviceItem.Container.PlugNew(devMLFB, module.Name, module.slotNo);
                            MyprogressInformation.ProgressBarAdd();
                            MyprogressInformation.TextBoxAdd("模块 " + module.OderNo + " 已经添加");
                            //fm.Invoke(delePBAdd, pb);//进度条增加                            
                            //fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");//添加文本信息
                        }

                    }
                }
            }
            return "成功添加";

        }

        private string AddDrvModule()//添加驱动模块
        {
            Device device = null;
            DeviceItem subModul = null;
            string MLFB = "OrderNumber:" + OderNo + "/" + Version;
            string name = Name;
            //deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
            //deleProgressBarAdd delePBAdd = new deleProgressBarAdd(ProgressBarAdd);
            try
            {
                device = myProject.Devices.CreateWithItem(MLFB, name, null);
                myDevice = device;
                DeviceName = device.Name;
                MyprogressInformation.TextBoxAdd("模块 " + OderNo + " 已经添加");
                MyprogressInformation.ProgressBarAdd();
                //Invoke(deletextboxadd, tb, "模块 " + im.OderNo + " 已经添加");
                //return "添加成功";
                //return StatusText;
            }
            catch (Exception e)
            {
                //StatusText = e.Message;
                return e.Message;
            }
            if (device != null)
            {
                string sssss = device.Name;
                foreach (Moduletype module in Modules)
                {
                    foreach (DeviceItem di in device.DeviceItems)
                    {
                        if (di.Classification == DeviceItemClassifications.HM)
                        {
                            if (module.type == "1000")
                            {
                                if (type == "G")
                                {
                                    MLFB = "OrderNumber:" + module.OderNo + "/" + module.Version;
                                    subModul = di.PlugNew(MLFB, module.Name, 3);
                                    MyprogressInformation.ProgressBarAdd();
                                    MyprogressInformation.TextBoxAdd("模块 " + module.OderNo + " 已经添加");
                                    //fm.Invoke(delePBAdd, pb);//进度条增加 
                                    //fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");
                                }
                                else if (type == "S")
                                {
                                    MLFB = "OrderNumber:" + module.OderNo;
                                    subModul = di.PlugNew(MLFB, module.Name, 65535);
                                    MyprogressInformation.ProgressBarAdd();
                                    MyprogressInformation.TextBoxAdd("模块 " + module.OderNo + " 已经添加");
                                    //fm.Invoke(delePBAdd, pb);//进度条增加 
                                    //fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");
                                }
                            }
                            else if ((module.type == "2000") && (subModul != null))
                            {
                                MLFB = "OrderNumber:" + module.OderNo + module.Version;
                                subModul.Container.PlugNew(MLFB, module.Name, 65535);
                                MyprogressInformation.ProgressBarAdd();
                                MyprogressInformation.TextBoxAdd("模块 " + module.OderNo + " 已经添加");
                                //fm.Invoke(delePBAdd, pb);//进度条增加 
                                //fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");
                            }
                        }
                    }
                }
            }
            return "成功添加";

        }

        public string AddToSubNet(Subnet subnet)//将站点连接到子网
        {
            //NetworkInterface networkInterface = null;
            string devname = "station" + Name;

            try
            {
                if (type == "G")
                {
                    foreach (DeviceItem deviceItem in myProject.Devices.Find("SINAMICS G_1").DeviceItems[1].DeviceItems)
                    {
                        if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
                        {
                            networkInterface = deviceItem.GetService<NetworkInterface>();
                            //networkInterface = networkInterface;
                            networkInterface.Nodes.First().SetAttribute("Address", IPAdress);
                            try
                            {
                                networkInterface.Nodes.First().ConnectToSubnet(subnet);
                                MyprogressInformation.ProgressBarAdd();
                                MyprogressInformation.TextBoxAdd("站点" + Name + " 的子网已经添加");
                                return "成功连接";
                                
                                //myForm.Invoke(delePBAdd, myProgressBar);
                                //myForm.Invoke(deletextboxadd,myTextBox, "站点" + myStations[i].Name + "的子网已经添加");  
                            }
                            catch (Exception exp)
                            {
                                return exp.Message;
                            }
                        }
                    }

                }
                else
                {
                    foreach (DeviceItem deviceItem in myProject.Devices.Find(devname).DeviceItems[1].DeviceItems)
                    {
                        if (JudgeInterface(deviceItem.Name))//deviceItem.Name == "PROFINET 接口_1" || deviceItem.Name == "PROFINET 接口")
                        {
                            networkInterface = deviceItem.GetService<NetworkInterface>();
                            //mt.networkInterface = networkInterface;
                            networkInterface.Nodes.First().SetAttribute("Address", IPAdress);
                            try
                            {
                                networkInterface.Nodes.First().ConnectToSubnet(subnet);
                                MyprogressInformation.ProgressBarAdd();
                                MyprogressInformation.TextBoxAdd("站点" + Name + " 的子网已经添加");
                                return "成功连接";
                            }
                            catch (Exception exp)
                            {
                                return exp.Message;
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                return exp.Message; ;
            }
            return null;
        }
        private bool JudgeInterface(string ifName)//判断接口
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

        public string AddToIOSys(IoSystem iosystem)
        {
            //NetworkInterface networkInterface = mt.networkInterface;
            //IoSystem _ioSystem = iosystem.IoSystems[0];

            try
            {
                networkInterface.IoConnectors.First().ConnectToIoSystem(iosystem);
                MyprogressInformation.ProgressBarAdd();
                MyprogressInformation.TextBoxAdd("站点" + Name + " 的PNIO系统已经添加");
                //myForm.Invoke(delePBAdd, myProgressBar);
                //myForm.Invoke(deletextboxadd, myTextBox, "站点 " + myStations[i].Name + " 的PNIO系统已经添加");
            }

            catch (Exception exp)
            {
                return exp.Message;
            }

            return "成功添加";
        }

        public string ImportBlockFromGlobalLibrary(UserGlobalLibrary globalLibrary)//导入全局库,必须先获取mySoftware
        {
            PlcSoftware software = GetSoftware();
            
            if (globalLibrary != null)
            {
                foreach (LibraryType libTypeByName in globalLibrary.TypeFolder.Types)
                {
                    if (libTypeByName is CodeBlockLibraryType)
                    {
                        software.BlockGroup.Blocks.CreateFrom((CodeBlockLibraryTypeVersion)libTypeByName.Versions[0]);
                        MyprogressInformation.TextBoxAdd("库文件 "+ libTypeByName.Name+ " 导入成功");
                        MyprogressInformation.ProgressBarAdd();
                    }
                }
            }
            return "导入成功";
        }
        //导入XML文件生成功能块
        public string ImportBlockFromXML(Factory factory)
        {
            PlcSoftware software = GetSoftware();
            PlcBlockGroup blockGroup = software.BlockGroup;
            //blockGroup.Blocks.Import(new FileInfo(@"D:\Blocks\myBlock.xml"), ImportOptions.Override);
            factory.MyprogressInformation = MyprogressInformation;//传入过程对象
            try
            {
                factory.ImportBlockFromXML(blockGroup);//根据工厂对象导入XML
            }
            catch(Exception exp)
            {
                MyprogressInformation.TextBoxAdd("没有正确设置XML文件路径");
            }

            return null;
        }

        public void ImportBlockFromXML(string path)
        {
            PlcSoftware software = GetSoftware();
            PlcBlockGroup blockGroup = software.BlockGroup;
            FileInfo fileInfo = new FileInfo(path);
            blockGroup.Blocks.Import(fileInfo, ImportOptions.Override);

        }
        //更新库功能块到项目
        public string LibraryUpdate(UserGlobalLibrary globalLibrary)
        {            
            PlcSoftware software = GetSoftware();  
            if ((software != null) && (globalLibrary != null))
            {
                IUpdateProjectScope[] scope = { software as IUpdateProjectScope };
                globalLibrary.UpdateProject(new[] { globalLibrary.TypeFolder }, scope);
            }            
            return "库更新成功";
        }
        public string CompileSoftWare()//编译软件
        {
            PlcSoftware software = GetSoftware(15);
            if (software != null)
            {
                software.GetService<ICompilable>().Compile();
                return "编译软件成功";
            }
            else
            {
                return "软件无法编译";
            }
        }
        public string ExportBlockToXML(FileInfo path)
        {
            PlcSoftware software = GetSoftware();
            if (software != null)
            {
                string stringpath = path.ToString();
                foreach (PlcBlock block in software.BlockGroup.Blocks)
                {
                    block.Export(new FileInfo(string.Format(stringpath + "{0}.xml", block.Name)), ExportOptions.None);
                }
                //导出组文件夹中的功能块
                GroupExport(software.BlockGroup, stringpath);
            }
            return "导出成功";
        }
        private void GroupExport(PlcBlockGroup plcbg, string path)
        {
            foreach (PlcBlockGroup pbg in plcbg.Groups)
            {
                string stringpath = path + pbg.Name + @"\";
                foreach (PlcBlock pb in pbg.Blocks)
                {
                    pb.Export(new FileInfo(string.Format(stringpath + "{0}.xml", pb.Name)), ExportOptions.None);
                }
                GroupExport(pbg, stringpath);
            }
        }
        private PlcSoftware GetSoftware()//获取Software，必须先获取myDevice
        {            
            try
            {                
                SoftwareContainer softwareContainer = null;
                //SoftwareContainer softwareContainer = MainPLC.DeviceItems[1].GetService<SoftwareContainer>();
                foreach (DeviceItem di in myDevice.DeviceItems)
                {
                    softwareContainer = di.GetService<SoftwareContainer>();
                    if (softwareContainer != null)
                    {
                        //MyprogressInformation.TextBoxAdd("请选择CPU站点");
                        break;
                    }

                }
                if (softwareContainer != null)
                {
                    if (softwareContainer.Software is PlcSoftware)
                    {
                        PlcSoftware software = softwareContainer.Software as PlcSoftware;
                        return software;
                    }
                    else
                    {
                        MyprogressInformation.TextBoxAdd("请选择CPU站点");
                    }
                }
                else
                {
                    MyprogressInformation.TextBoxAdd("请选择CPU站点");
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        private PlcSoftware GetSoftware(int flag)
        {
            try
            {
                SoftwareContainer softwareContainer = null;
                //SoftwareContainer softwareContainer = MainPLC.DeviceItems[1].GetService<SoftwareContainer>();
                foreach (DeviceItem di in myDevice.DeviceItems)
                {
                    softwareContainer = di.GetService<SoftwareContainer>();
                    if (softwareContainer != null) break;

                }
                if (softwareContainer != null)
                {
                    if (softwareContainer.Software is PlcSoftware)
                    {
                        PlcSoftware software = softwareContainer.Software as PlcSoftware;
                        return software;
                    }
                }               
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
    public class Moduletype : UnitType
    {
        public int slotNo { get; set; }
        public string type { get; set; }
    }  


    public class StationsFunction
    {
        public string StatusText { get; set; }
        static public string SStatusText {get;set;}

        //public delegate void deleTextBoxAdd(TextBox tb, string st);
        //public delegate void deleProgressBarAdd(ProgressBar pb);
        /// <summary>
        /// 获取项目中的站点对象
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        static public Device GetDevice(StationType mt, Project project)
        {
            string Masterdevname = mt.Name;
            try
            {
                return project.Devices.Find(Masterdevname);
            }
            catch (Exception exp)
            {
                SStatusText =  exp.Message;
                return null;
            }
        }
        static private bool JudgeInterface(string ifName)
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
        /// <summary>
        /// 获取设备网络接口
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        static private NetworkInterface GetNetworkInterface(Device device)
        {
            foreach (DeviceItem di in device.DeviceItems[1].DeviceItems)
            {
                if (JudgeInterface(di.Name))
                {
                    return di.GetService<NetworkInterface>();
                }
            }
            return null;
        }
        //static public string AddCPU(StationType cpu, Project project)
        //{
        //    string MLFB = "OrderNumber:" + cpu.OderNo + "/" + cpu.Version;
        //    //myCpuType = cpu;
        //    string name = cpu.Name;
        //    string devname = "station" + cpu.Name;
        //    bool found = false;
        //    try
        //    {
        //        foreach (Device device in project.Devices)
        //        {
        //            DeviceItemComposition deviceItemAggregation = device.DeviceItems;
        //            foreach (DeviceItem deviceItem in deviceItemAggregation)
        //            {
        //                if (deviceItem.Name == devname || device.Name == devname)
        //                {
        //                    SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
        //                    if (softwareContainer != null)
        //                    {
        //                        if (softwareContainer.Software is PlcSoftware)
        //                        {
        //                            PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
        //                            if (controllerTarget != null)
        //                            {
        //                                found = true;

        //                            }
        //                        }
        //                        if (softwareContainer.Software is HmiTarget)
        //                        {
        //                            HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
        //                            if (hmitarget != null)
        //                            {
        //                                found = true;

        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (found == true)
        //        {
        //            return "Device " + cpu.Name + " already exists";
        //        }
        //        else
        //        {
        //            Device deviceName = project.Devices.CreateWithItem(MLFB, name, devname);

        //            return "Add Device Name: " + name + " with Order Number: " + cpu.OderNo + " and Firmware Version: " + cpu.Version;
        //        }
        //        //return StatusText;
        //    }
        //    catch (Exception e)
        //    {
        //        //StatusText = e.Message;
        //        return e.Message;
        //    }
        //}
        //static public string AddModule(StationType cpu, Moduletype module, Project project)
        //{
        //    Device deviceMore = null;
        //    string MLFB = "OrderNumber:" + module.OderNo + "/" + module.Version;
        //    string name = module.Name;
        //    string Masterdevname = "station" + cpu.Name;
        //    try
        //    {
        //        deviceMore = project.Devices.Find(Masterdevname);
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message;//StatusText = exp.Message;
        //    }
        //    try
        //    {
        //        foreach (DeviceItem deviceItem in deviceMore.DeviceItems)
        //        {
        //            if (deviceItem.Container.CanPlugNew(MLFB, module.Name, module.slotNo))
        //            {
        //                DeviceItem newPluggedDeviceItem = deviceItem.Container.PlugNew(MLFB, module.Name, module.slotNo);
        //            }

        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message;               
        //    }
        //    return "";
        //}

        //static public string AddDrvModule(StationType Drv, Moduletype module, Project project)
        //{
        //    Device deviceMore = null;
        //    DeviceItem subModul = null;
        //    string MLFB = "OrderNumber:" + module.OderNo + module.Version;
        //    string name = module.Name;            
        //    try
        //    {
        //        deviceMore = project.Devices.Find("SINAMICS S_1");
        //        if (module.type == "2000")
        //        {
        //            subModul = deviceMore.DeviceItems[1];
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message;//StatusText = exp.Message;
        //    }
        //    try
        //    {
        //        if (module.type == "1000")
        //        {
        //            deviceMore.PlugNew(MLFB, module.Name, 65535);
        //        } 
        //        else if(module.type =="2000")
        //        {
        //            subModul.Container.PlugNew(MLFB, module.Name, 65535);
        //        }            
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message;
        //    }
        //    return "";
        //}

        //static public string AddMasterModule(StationType im, Project project,ProgressBar pb,TextBox tb,Form fm)
        //{
        //    Device device = null;
        //    string MLFB = "OrderNumber:" + im.OderNo + "/" + im.Version;
        //    string name = im.Name;
        //    string devname = "station" + im.Name;

        //    deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
        //    deleProgressBarAdd delePBAdd = new deleProgressBarAdd(ProgressBarAdd);
        //    try
        //    {
        //        device = project.Devices.CreateWithItem(MLFB, name, devname);
        //        im.myDevice = device;
        //        im.DeviceName = device.Name;
        //        //return "添加成功";
        //        //return StatusText;
        //        fm.Invoke(deletextboxadd, tb, "模块 "+im.OderNo+ " 已经添加");
        //    }
        //    catch (Exception e)
        //    {                
        //        return e.Message;
        //    }

        //    if(device!=null)
        //    {
        //        //string sssss = device.Name;
        //        foreach (Moduletype module in im.Modules)
        //        {
        //            foreach (DeviceItem deviceItem in device.DeviceItems)
        //            {
        //                string devMLFB = "OrderNumber:" + module.OderNo + "/" + module.Version;
        //                if (deviceItem.Container.CanPlugNew(devMLFB, module.Name, module.slotNo))
        //                {
        //                    DeviceItem newPluggedDeviceItem = deviceItem.Container.PlugNew(devMLFB, module.Name, module.slotNo);

        //                    fm.Invoke(delePBAdd, pb);//进度条增加                            
        //                    fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");//添加文本信息
        //                }

        //            }
        //        }
        //    }
        //    return "成功添加";

        //}

        //static public string AddDrvMasterModule(StationType im, Project project,ProgressBar pb,TextBox tb,Form fm)
        //{
        //    Device device = null;           
        //    DeviceItem subModul = null;
        //    string MLFB = "OrderNumber:" + im.OderNo + "/" + im.Version;
        //    string name = im.Name;            
        //    deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
        //    deleProgressBarAdd delePBAdd = new deleProgressBarAdd(ProgressBarAdd);
        //    try
        //    {
        //        device = project.Devices.CreateWithItem(MLFB, name, null);
        //        im.myDevice = device;
        //        im.DeviceName = device.Name;
        //        fm.Invoke(deletextboxadd, tb, "模块 " + im.OderNo + " 已经添加");
        //        //return "添加成功";
        //        //return StatusText;
        //    }
        //    catch (Exception e)
        //    {
        //        //StatusText = e.Message;
        //        return e.Message;
        //    }
        //    if(device!=null)
        //    {
        //        string sssss = device.Name;
        //        foreach (Moduletype module in im.Modules)
        //        {
        //            foreach (DeviceItem di in device.DeviceItems)
        //            {                        
        //                if (di.Classification == DeviceItemClassifications.HM)
        //                {                            
        //                    if (module.type == "1000")
        //                    {
        //                        if (im.type == "G")
        //                        {
        //                            MLFB = "OrderNumber:" + module.OderNo + "/" + module.Version;
        //                            subModul = di.PlugNew(MLFB, module.Name, 3);
        //                            fm.Invoke(delePBAdd, pb);//进度条增加 
        //                            fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");
        //                        }
        //                        else if (im.type =="S")
        //                        {
        //                            MLFB = "OrderNumber:" + module.OderNo;
        //                            subModul = di.PlugNew(MLFB, module.Name, 65535);
        //                            fm.Invoke(delePBAdd, pb);//进度条增加 
        //                            fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");
        //                        }                           
        //                    }
        //                    else if ((module.type == "2000") && (subModul != null))
        //                    {
        //                        MLFB = "OrderNumber:" + module.OderNo + module.Version;
        //                        subModul.Container.PlugNew(MLFB, module.Name, 65535);
        //                        fm.Invoke(delePBAdd, pb);//进度条增加 
        //                        fm.Invoke(deletextboxadd, tb, "模块 " + module.OderNo + " 已经添加");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return "成功添加";

        //}
        /// <summary>
        /// 更改设备名称
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        static public string ChangeDeviceName(StationType mt, Project project)
        {
            NetworkInterface ni = GetNetworkInterface(GetDevice(mt, project));
            ni.Nodes.First().SetAttribute("PnDeviceNameAutoGeneration", false);
            ni.Nodes.First().SetAttribute("PnDeviceName", mt.DeviceName);
            //ni.Nodes.First().SetAttribute("Address", "172.22.215.215");
            return SStatusText;
        }       
        /// <summary>
        /// 获取驱动对象
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        //static public DriveObject GetDrvObject( Project project)
        //{            
        //    DeviceItem item = project.Devices.Find("SINAMICS G_1").Items[0].Items[0];
        //    return item.GetService<DriveObjectContainer>().DriveObjects[0];
        //    //return null;
        //}
        //static public void TextBoxAdd(TextBox tb,string st)
        //{
        //    tb.Text = tb.Text + st + "\r\n";
        //}
        //static public void ProgressBarAdd(ProgressBar pb)
        //{
        //    pb.Value++;
        //}
    }
}
