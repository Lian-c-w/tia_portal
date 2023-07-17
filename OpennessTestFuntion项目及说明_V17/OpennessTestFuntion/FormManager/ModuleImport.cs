using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunctionManager;
using System.IO;
using FileManager;
using Siemens.Engineering.SW.Blocks;

namespace FormManager
{
    public partial class ModuleImport : Form
    {
        //private FunctionManager.FunctionManager myFM;
        private GeneralFileManager myGFM;
        public string mySelectString { get; set; }
        public ModuleImport()
        {
            //myFM = fm;
            myGFM = new GeneralFileManager();           
            InitializeComponent();
            //myGFM.SelectFolderFile(textBoxPath.Text);
            //myGFM.SelectDirectores(ModuleSelect);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            int BlockCount = myGFM.CountFoldersFiles(textBoxPath.Text + ModuleSelect.Text);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = BlockCount + 1;
            progressBar1.Value = 0;
            try
            {
                FileInfo libpath = new FileInfo(textBoxLibrary.Text);
                //myFM.LibraryImport(textBoxCPUName.Text, libpath);
                //myFM.CopyMasterCopies(libpath);
                //myFM.CreateDeFromMasterCopies();
                progressBar1.Value++;
            }
            catch (Exception exp)
            {
                //myFM.StatusText = exp.Message;
            }

            //myGFM = new GeneralFileManager();
            myGFM.SelectFolderFile(textBoxPath.Text + ModuleSelect.Text);//获取指定路径内的信息 
            //PlcBlockGroup pbg = myFM.GetGroup(textBoxCPUName.Text);//获取程序组
            foreach (FileInfo fi in myGFM.myFiles)
            {
                FileInfo absfi = new FileInfo(fi.FullName);
                //myFM.XMLImport(pbg, absfi);
                progressBar1.Value++;
            }
            //myFM.ImportGroup( pbg, myGFM.myDirs,progressBar1); //迭代导入

            //myFM.SWCompile(textBoxCPUName.Text);//导入完成后，编译软件
        }  

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 关闭窗体时关闭库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            //myFM.CloseLibrary();
        }        
        /// <summary>
        /// 更新CPU名称
        /// </summary>
        /// <param name="info"></param>
        public void UpdateCpuName(string info)
        {
            textBoxCPUName.Text = info;
            Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 根据库更新项目中的块版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LibraryUpdate_Click(object sender, EventArgs e)
        {
            FileInfo libpath = new FileInfo(textBoxLibrary.Text);
            //myFM.LibraryUpdate(textBoxCPUName.Text, libpath);
            //myFM.SWCompile(textBoxCPUName.Text);
        }
        /// <summary>
        /// 刷新选择内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            myGFM.SelectFolderFile(textBoxPath.Text);
            myGFM.SelectDirectores(ModuleSelect);
        }
    }
}
