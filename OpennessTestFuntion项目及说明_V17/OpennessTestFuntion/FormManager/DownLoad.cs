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

namespace FormManager
{
    public partial class DownLoad : Form
    {
        public TiaPortalEX myTiaPortalEX { get; set; }
        public DownLoad()
        {
            InitializeComponent();
            下载选项.SelectedIndex = 0;
            //myTiaPortalEX.GetNetAdapterName(选择网卡);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            myTiaPortalEX.Download(下载选项.SelectedIndex,选择网卡,目标IP地址,接口);
            richTextBox1.Text = myTiaPortalEX.myDownloadResult;
        }

 

        private void DownLoad_Shown(object sender, EventArgs e)
        {
            try
            {
                myTiaPortalEX.GetNetAdapterName(选择网卡);
                选择网卡.SelectedIndex = 0;
                myTiaPortalEX.GetInterface(选择网卡, 接口);
                接口.SelectedIndex = 0;
            }
            catch
            {
                richTextBox1.Clear();
                richTextBox1.Text = "没有连接博途";
            }
        }

        private void 上载_Click(object sender, EventArgs e)
        {
            myTiaPortalEX.UpLoad(选择网卡, 目标IP地址);
        }
    }
}
