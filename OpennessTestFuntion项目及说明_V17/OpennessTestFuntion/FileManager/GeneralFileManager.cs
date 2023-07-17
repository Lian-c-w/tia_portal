using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public class GeneralFileManager
    {
        public FileInfo[] myFiles { get; set; }
        public DirectoryInfo[] myDirs { get; set; }
        private DirectoryInfo myRootDir { get; set; }
        /// <summary>
        /// 选择文件，并且把文件名显示在ListBox控件里
        /// </summary>
        /// <param name="lb"></param>
        public void SelectFile(ListBox lb)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lb.Items.AddRange(ofd.FileNames);
                lb.SetSelected(0, true);               
            }
        }
        /// <summary>
        /// 选择文件夹，并且把文件夹名称显示在ListBox控件里
        /// </summary>
        /// <param name="lb"></param>
        public void SelectDirectores(ListBox lb)
        {
            lb.Items.Clear();
            List<string> DirNames = new List<string>();
                        
            if (myDirs != null)
            {                
                foreach (DirectoryInfo di in myDirs)
                {
                    DirNames.Add(di.Name);
                }
            }
            string[] dns = DirNames.ToArray();
            lb.Items.AddRange(dns);
        }
        /// <summary>
        /// 带文件夹选择文件
        /// </summary>
        public void SelectFolderFile()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                myRootDir = new DirectoryInfo(fbd.SelectedPath);
                myFiles = myRootDir.GetFiles();
                myDirs = myRootDir.GetDirectories();               
            }
        }
        /// <summary>
        /// 重载，直接选择目录
        /// </summary>
        /// <param name="path"></param>
        public void SelectFolderFile(string path)
        {
            if(path!=null)
            {
                myRootDir = new DirectoryInfo(path);
                myFiles = myRootDir.GetFiles();
                myDirs = myRootDir.GetDirectories();
            }
        }
        /// <summary>
        /// 获取此文件夹下所有文件夹，文件个数
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int CountFoldersFiles(string path)
        {
            int count = 0;
            DirectoryInfo dif = null;
            if (path != null)
            {
                dif = new DirectoryInfo(path);
                count += dif.GetFiles().Count();
                count += dif.GetDirectories().Count();
                count += CountSubFoldersFiles(dif.GetDirectories());
                return count;
            }
            return 0;
        }
        private int CountSubFoldersFiles(DirectoryInfo[] dis)
        {
            int count = 0;
            foreach (DirectoryInfo di in dis)
            {
                count += di.GetFiles().Count();
                count += di.GetDirectories().Count();
                count += CountSubFoldersFiles(di.GetDirectories());
            }
            return count;
        }
    }
    public class ProgressInformation
    {
        public ProgressBar MyprogressBar { get; set; }
        public TextBox MytextBox { get; set; }
        public Form Myform { get; set; }

        public void TextBoxAdd(string text)
        {
            TextBoxAdd(MytextBox,text);
            //Myform.Invoke(deletextboxadd,MytextBox, text);
        }
        public void ProgressBarAdd()
        {
            ProgressBarAdd(MyprogressBar);
            //Myform.Invoke(delePBAdd, MyprogressBar);
        }
        public void CountProgressBar(int max)
        {
            CountProgressBar(MyprogressBar, max);
            //Myform.Invoke(deleCountPB, MyprogressBar,max);
        }
        public void ClearTextBox()
        {
            ClearTextBox(MytextBox);
            //Myform.Invoke(deleClearTB, MytextBox);
        }

        private delegate void deleTextBoxAdd(TextBox tb, string st);
        private delegate void deleProgressBarAdd(ProgressBar pb);
        private delegate void deleCountProgressBar(ProgressBar pb, int max);
        private delegate void deleClearTextBox(TextBox tb);

        deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
        deleProgressBarAdd delePBAdd = new deleProgressBarAdd(ProgressBarAdd);
        deleCountProgressBar deleCountPB = new deleCountProgressBar(CountProgressBar);
        deleClearTextBox deleClearTB = new deleClearTextBox(ClearTextBox);
        static private void TextBoxAdd(TextBox tb, string st)
        {
            tb.Text = tb.Text + st + "\r\n";
        }
        static private void ProgressBarAdd(ProgressBar pb)
        {
            pb.Value++;
        }
        static private void CountProgressBar(ProgressBar pb,int max)
        {
            pb.Minimum = 0;
            pb.Maximum = max + 1;
            pb.Value = 0;
        }
        static private void ClearTextBox(TextBox tb)
        {
            tb.Clear();
        }
    }
}
