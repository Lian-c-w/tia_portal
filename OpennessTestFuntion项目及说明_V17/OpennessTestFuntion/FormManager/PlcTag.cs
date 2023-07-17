using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FunctionManager;

namespace FormManager
{
    public partial class PlcTag : Form
    {
        //private FunctionManager.FunctionManager myFM;
        private StationType myMT;
        public PlcTag()
        {
            //myFM = fm;
            myMT = new StationType();
            InitializeComponent();
        }
        /// <summary>
        /// 导入PLC变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            myMT.Name = textBoxCPUName.Text;
            //myFM.PLCTagImport(myMT, new FileInfo(textBoxImport.Text));
        }
        /// <summary>
        /// 导出PLC变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            myMT.Name = textBoxCPUName.Text;
            FileInfo fi = new FileInfo(textBoxExport.Text+ "{0}.xml");
            //myFM.PLCTagExport(myMT,fi);
        }

        private void textBoxImport_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
