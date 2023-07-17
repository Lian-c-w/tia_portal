using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.Library.MasterCopies;
using FileManager;
using System.Windows.Forms;



namespace FunctionManager
{
    class CGetSW
    {
        static public PlcSoftware GetSW(string CPUName, Project project)
        {
            string devname = CPUName;
            Device MainPLC = null;
            try
            {
                MainPLC = project.Devices.Find(devname);
                foreach (DeviceGroup dg in project.DeviceGroups)
                {
                    MainPLC = dg.Devices.Find(devname);
                }
                SoftwareContainer softwareContainer = null;
                //SoftwareContainer softwareContainer = MainPLC.DeviceItems[1].GetService<SoftwareContainer>();
                foreach (DeviceItem di in MainPLC.DeviceItems)
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
        static public void Compile(string CPUName, Project project)
        {
            PlcSoftware software = GetSW(CPUName, project);
            software.GetService<ICompilable>().Compile();
        }
  
    }
    class XMLFunction
    {
        public string StatusText { get; set; }

        static private void GroupExport(PlcBlockGroup plcbg, string path)
        {
            foreach (PlcBlockGroup pbg in plcbg.Groups)
            {
                string stringpath = path + pbg.Name +@"\";
                foreach (PlcBlock pb in pbg.Blocks)
                {                                 
                    pb.Export(new FileInfo(string.Format(stringpath + "{0}.xml", pb.Name)), ExportOptions.None);
                }
                GroupExport(pbg, stringpath);
            }
        }
        static public string XMLImport(string CPUName, Project project, FileInfo path)
        {  
            PlcSoftware software = CGetSW.GetSW(CPUName, project);
            if (software != null)
            {
                IList<PlcBlock> blocks = software.BlockGroup.Blocks.Import(path, ImportOptions.Override);

            }           
            return "成功导入";
        }
        static public string XMLImport(PlcBlockGroup pbg,FileInfo path)
        {
            pbg.Blocks.Import(path, ImportOptions.Override);
            return "成功导入";
        }
        static public string XMLExport(string CPUName, Project project, FileInfo path)
        {    
            PlcSoftware software = CGetSW.GetSW(CPUName, project);
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
        static public PlcBlockGroup CreateGroup(PlcBlockGroup plcbg, string group)
        {
            //PlcSoftware software = CGetSW.GetSW(CPUName, project);
            if (plcbg != null)
            {
                return plcbg.Groups.Create(group);              
            }
            return null;
        }
        /// <summary>
        /// 获取程序组
        /// </summary>
        /// <param name="CPUName"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        static public PlcBlockGroup GetGroup(string CPUName, Project project)
        {
            PlcSoftware software = CGetSW.GetSW(CPUName, project);
            if (software != null)
            {
                return software.BlockGroup;
            }
            return null;
        }
        /// <summary>
        /// 导入PLC变量
        /// </summary>
        /// <returns></returns>
        static public string PLCTagImport(StationType mt, Project project,FileInfo path)
        {
            PlcSoftware software = CGetSW.GetSW(mt.Name, project);

            if (software != null)
            {
                software.TagTableGroup.TagTables.Import(path, ImportOptions.Override);
            }
            return "成功导入";
        }
        /// <summary>
        /// 导出PLC变量
        /// </summary>
        /// <returns></returns>
        static public string PLCTagExport(StationType mt, Project project, FileInfo path)
        {
            PlcSoftware software = CGetSW.GetSW(mt.Name, project);
            if (software != null)
            {
                foreach (PlcTagTable table in software.TagTableGroup.TagTables)
                {
                    table.Export(new FileInfo(string.Format(path.ToString(), table.Name)), ExportOptions.WithDefaults);
                }
            }
            return "成功导出";
        }

        ///////////////////////////////////////////////////////
        static public void ImportGroup(PlcBlockGroup plcBG, DirectoryInfo[] dis, ProgressBar pb)
        {
            foreach (DirectoryInfo di in dis)
            {
                PlcBlockGroup subplcbg = plcBG.Groups.Create(di.Name);//fm.CreateGroup(plcBG, di.Name);
                pb.Value++;
                FileInfo[] fis = di.GetFiles();
                DirectoryInfo[] subdis = di.GetDirectories();
                foreach (FileInfo fi in fis)
                {
                    FileInfo absfi = new FileInfo(fi.FullName);
                    //fm.XMLImport(subplcbg, absfi);
                    subplcbg.Blocks.Import(absfi, ImportOptions.Override);
                    pb.Value++;
                }
                ImportGroup(subplcbg, subdis, pb);
            }
        }
        static public void ImportGroup(PlcBlockGroup plcBG, DirectoryInfo[] dis)
        {
            foreach (DirectoryInfo di in dis)
            {
                PlcBlockGroup subplcbg = plcBG.Groups.Create(di.Name);//fm.CreateGroup(plcBG, di.Name);
                //pb.Value++;
                FileInfo[] fis = di.GetFiles();
                DirectoryInfo[] subdis = di.GetDirectories();
                foreach (FileInfo fi in fis)
                {
                    FileInfo absfi = new FileInfo(fi.FullName);
                    //fm.XMLImport(subplcbg, absfi);
                    subplcbg.Blocks.Import(absfi, ImportOptions.Override);
                    //pb.Value++;
                }
                ImportGroup(subplcbg, subdis);
            }
        }
        static public void ImportGroup(PlcBlockGroup plcBG, Workshop ws, ProgressBar pb)
        {
            ////DirectoryInfo di = ws.Path;
            ////PlcBlockGroup subplcbg = plcBG.Groups.Create(di.Name);//fm.CreateGroup(plcBG, di.Name);
            //pb.Value++;
            ////FileInfo[] fis = di.GetFiles();
            //DirectoryInfo[] subdis = di.GetDirectories();
            //foreach (FileInfo fi in fis)
            //{
            //    FileInfo absfi = new FileInfo(XMLManager.ModifyFileAdd(ws, fi));
            //    //fm.XMLImport(subplcbg, absfi);
            //    subplcbg.Blocks.Import(absfi, ImportOptions.Override);
            //    pb.Value++;
            //}
            //ImportGroup(subplcbg, ws, subdis, pb);
        }
        static public void ImportGroup(PlcBlockGroup plcBG, Workshop ws, DirectoryInfo[] dis, ProgressBar pb)
        {
            foreach (DirectoryInfo di in dis)
            {
                PlcBlockGroup subplcbg = plcBG.Groups.Create(di.Name);//fm.CreateGroup(plcBG, di.Name);
                pb.Value++;
                FileInfo[] fis = di.GetFiles();
                DirectoryInfo[] subdis = di.GetDirectories();
                foreach (FileInfo fi in fis)
                {
                    foreach (TankType tt in ws.Tanks)
                    {
                        if (tt.Name == fi.Name)
                        {
                            FileInfo absfi = new FileInfo(fi.FullName);
                            //fm.XMLImport(subplcbg, absfi);
                            subplcbg.Blocks.Import(absfi, ImportOptions.Override);
                            pb.Value++;
                        }
                    }
                }
                ImportGroup(subplcbg, subdis, pb);
            }
        }

        ////////////////////////////////////////////////////////
    }
    class LibraryFunction
    {
        public string StatusText { get; set; }
        static public string LibraryImport(string CPUName, TiaPortal portal, Project project, FileInfo path)
        {           
            UserGlobalLibrary userLib = null;
            PlcSoftware software = CGetSW.GetSW(CPUName, project);
            //string ST;          
            try
            {
                userLib = portal.GlobalLibraries.Open(path, OpenMode.ReadWrite);
            }
            catch (Exception exp)
            {
                return exp.Message;
            }

            if(userLib!=null)
            {
                foreach(LibraryType libTypeByName in userLib.TypeFolder.Types)
                {                    
                    if(libTypeByName is CodeBlockLibraryType)
                    {
                        software.BlockGroup.Blocks.CreateFrom((CodeBlockLibraryTypeVersion)libTypeByName.Versions[0]);
                    }                    
                }               
            }  
            return "导入成功";
        }
        static public string LibraryUpdate(string CPUName, TiaPortal portal, Project project, FileInfo path)
        {
            UserGlobalLibrary userLib = null;
            PlcSoftware software = CGetSW.GetSW(CPUName, project);
            try
            {
                userLib = portal.GlobalLibraries.Open(path, OpenMode.ReadWrite);
            }
            catch (Exception exp)
            {
                return  exp.Message;
            }

            if ((software != null)&&(userLib!=null))
            {
                IUpdateProjectScope[] scope = { software as IUpdateProjectScope };
                userLib.UpdateProject(new[] { userLib.TypeFolder }, scope);

            }
            //software.GetService<ICompilable>().Compile();
            return "库更新成功";
        }
        static public string CopyMasterCopies(TiaPortal portal, Project project, FileInfo path)
        {
            UserGlobalLibrary userLib = null;
            
            try
            {
                userLib = portal.GlobalLibraries.Open(path, OpenMode.ReadWrite);
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
            foreach(MasterCopy mc in userLib.MasterCopyFolder.MasterCopies)
            {
                project.ProjectLibrary.MasterCopyFolder.MasterCopies.CreateFrom(mc);
            }
            return "拷贝成功";
        }
        /// <summary>
        /// 关闭库
        /// </summary>
        /// <param name="portal"></param>
        /// <returns></returns>
        static public string CloseLibrary(TiaPortal portal)
        {
            try
            {
                foreach (GlobalLibrary gl in portal.GlobalLibraries)
                {
                    if (gl is UserGlobalLibrary)
                    {
                        UserGlobalLibrary ugl = gl as UserGlobalLibrary;
                        ugl.Close();
                    }
                }
            }
            catch(Exception exp)
            {
                return exp.Message;
            }           
            return "关闭成功";
        }
        static public string CreateDeFormMasterCopies(Project project)
        {
            foreach(MasterCopy mc in project.ProjectLibrary.MasterCopyFolder.MasterCopies)
            {
                //Type ob = mc.GetType();
                //string name = mc.Name;
                if (mc.Name == "HMI_1")
                {
                    try
                    {
                        project.Devices.CreateFrom(mc);
                    }
                    catch (Exception exp)
                    {
                        return exp.Message;
                    }
                }              
            }
            return "创建成功";
        }
        /// <summary>
        /// 删除项目库中主拷贝的所有内容
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        static public string DeleteMasterCopiesFromProjecLib(Project project)
        {
            MasterCopy mc = project.ProjectLibrary.MasterCopyFolder.MasterCopies.FirstOrDefault();
            while(mc !=null)
            {
                mc.Delete();
                mc = project.ProjectLibrary.MasterCopyFolder.MasterCopies.FirstOrDefault();                
            }   
            return "删除成功";
        }

    }
}
