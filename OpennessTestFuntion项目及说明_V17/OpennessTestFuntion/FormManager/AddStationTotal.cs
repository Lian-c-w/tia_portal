using System;
using System.Threading;
using System.Windows.Forms;
using FileManager;
using FunctionManager;
using Siemens.Engineering;

namespace FormManager
{
    public partial class AddStationTotal : Form
    {
        
        private TreeView myTV;
        private Form myForm;
        private ProgressInformation MyprogressInformation = new ProgressInformation();

        public TiaPortalEX myTiaPortalEX { get; set; }

        //public TestFunctions .Form1         
        public AddStationTotal(TreeView tv,Form form)
        {
            
            myTV = tv;
            myForm = form;      
            InitializeComponent();
            MyprogressInformation.Myform = this;
            MyprogressInformation.MyprogressBar = progressBar1;
            MyprogressInformation.MytextBox = textBox1;
        }
        /// <summary>
        /// 计算进度条最大值
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private int CountPrMax(ExcelManager em)
        {
            int count = 0;
            try
            {
                for (int i = 0; i < em.myDS.Tables.Count; i++)
                {
                    for (int j = 2; j < em.myDS.Tables[i].Rows.Count; j++)
                    {
                        count++;
                    }
                }
                if (checkBoxSubnet.Checked == true)
                {
                    for (int i = 0; i < em.myDS.Tables.Count; i++)
                    {
                        count++;
                    }
                }
                if (checkBoxPNIO.Checked == true)
                {
                    for (int i = 0; i < em.myDS.Tables.Count; i++)
                    {
                        count++;
                    }
                }
                if (checkBoxTopu.Checked == true)
                {
                    for (int i = 0; i < em.myDS.Tables.Count - 1; i++)
                    {
                        count++;
                    }
                }
                return count;
            }
            catch(Exception exp)
            {
                return 0;
            }           
        }
        delegate string DelegateManager(TreeView tv);       

        private void AddConfirm_Click(object sender, EventArgs e)
        {           
            ProjectEX projectEX = myTiaPortalEX.GetProjectEX();
            projectEX.MyprogressInformation = MyprogressInformation;
            projectEX.myForm = myForm;
            
            projectEX.SubNet = checkBoxSubnet.Checked;
            projectEX.PNIO = checkBoxPNIO.Checked;
            projectEX.Topu = checkBoxTopu.Checked;
            
            projectEX.myTreeView = myTV;
            if (ExcelFilePath.Text != "")
            {
                projectEX.ExcelFilePath = ExcelFilePath.Text;
                projectEX.AddHardWare();
            }
            else
            {
                textBox1.Text = "必须输入Execl文件路径";
            }
            //Thread t = new Thread(projectEX.AddHardWare);
            //t.IsBackground = true;
            //t.Start();           

        }
    }
}
