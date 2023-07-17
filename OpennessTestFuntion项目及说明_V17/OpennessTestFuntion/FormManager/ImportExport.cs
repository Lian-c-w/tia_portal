using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FunctionManager;
using FileManager;
using Siemens.Engineering.SW.Blocks;

namespace FormManager
{
    public partial class ImportExport : Form
    {
        //private FunctionManager.FunctionManager myFM;
        private GeneralFileManager myGFM;
        public TiaPortalEX myTiaPortalEX { get; set; }
        public ImportExport()
        {
            //myFM = fm;
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSearch = new OpenFileDialog();
            fileSearch.Filter = "*.xml|*.xml|*.aml|*.aml";
            fileSearch.RestoreDirectory = true;
            fileSearch.ShowDialog();
            string ProjectPath = fileSearch.FileName.ToString();

            ProjectEX projectEX = myTiaPortalEX.GetProjectEX();//获取Portal对象中的projectEX对象
            StationType station = projectEX.GetStation(textBoxCPUName.Text);//根据名称获取站点中的站对象
            station.ImportBlockFromXML(ProjectPath);//将全局库导入该站点 

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            //FileInfo path = new FileInfo(textBoxExport.Text);   
            //myFM.XMLExport(textBoxCPUName.Text, path);            
            StationType station = null;
            
            try
            {
                FileInfo xmlpath = new FileInfo(textBoxExport.Text);
                //myTiaPortalEX.ImportGlobalLibrary(libpath);//按照路径导入全局库，并生成全局库对象
                ProjectEX projectEX = myTiaPortalEX.GetProjectEX();//获取Portal对象中的projectEX对象
                station = projectEX.GetStation(textBoxCPUName.Text);//根据名称获取站点中的站对象
                station.ExportBlockToXML(xmlpath);//将全局库导入该站点                
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void buttonUpDate_Click(object sender, EventArgs e)
        {
            //FileInfo libpath = new FileInfo(listBoxLibrary.Items[0].ToString());
            //myFM.LibraryUpdate(textBoxCPUName.Text, libpath);
            //myFM.SWCompile(textBoxCPUName.Text);
        }
        /// <summary>
        /// 添加XML文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFile_Click(object sender, EventArgs e)
        {
            myGFM = new GeneralFileManager();
            myGFM.SelectFolderFile();
            //GFM.SelectFile(listBoxFiles);
            //GFM.SelectFolderFile();
        }

        private void AddLibrary_Click(object sender, EventArgs e)
        {
            GeneralFileManager GFM = new GeneralFileManager();
            GFM.SelectFile(listBoxLibrary);
        }

        private void ImportExport_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 关闭窗口时，关闭打开的全局库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportExport_FormClosed(object sender, FormClosedEventArgs e)
        {
            //myFM.CloseLibrary();
        }
        /// <summary>
        /// 导入组和文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportGroupFiles_Click(object sender, EventArgs e)
        {
            //GeneralFileManager GFM = new GeneralFileManager();            
            //GFM.SelectFolderFile();
            //PlcBlockGroup pbg = myFM.GetGroup(textBoxCPUName.Text);
            //foreach (FileInfo fi in GFM.myFiles)
            //{               
            //    FileInfo absfi = new FileInfo(fi.FullName);
            //    myFM.XMLImport(pbg, absfi);
            //}
            //ImportGroup(myFM, pbg, GFM.myDirs);
            //myFM.SWCompile(textBoxCPUName.Text);
        }
        /// <summary>
        /// 迭代导入所有文件夹中的块
        /// </summary>
        // static private void ImportGroup(FunctionManager.FunctionManager fm, PlcBlockGroup plcBG, DirectoryInfo[] dis)
        //{            
        //    foreach( DirectoryInfo di in dis)
        //    {
        //        PlcBlockGroup subplcbg =  fm.CreateGroup(plcBG, di.Name);              
        //        FileInfo[] fis = di.GetFiles();
        //        DirectoryInfo[] subdis = di.GetDirectories();
        //        foreach(FileInfo fi in fis)
        //        {
        //            FileInfo absfi = new FileInfo(fi.FullName);
        //            fm.XMLImport(subplcbg, absfi);                    
        //        }
        //        ImportGroup(fm, subplcbg, subdis);
        //    }
        //}

        //private void GetSoftwareInfo_Click(object sender, EventArgs e)
        //{
        //    myFM.GetSFWTreeView(textBoxCPUName.Text, treeViewProgram);
        //}
        /// <summary>
        /// 更新CPU名称
        /// </summary>
        /// <param name="info"></param>
        public void UpdateCpuName(string info)
        {
            textBoxCPUName.Text = info;
            Refresh();
        }
    }
}
