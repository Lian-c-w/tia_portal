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
    public partial class CreateProject : Form
    {
        //private FunctionManager.FunctionManager myhd;
        public TiaPortalEX myTiaPortalEX { get; set; }
        public CreateProject()
        {
            //myhd = hd;
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            //myhd.CreatProject(ProjectPath.Text, ProjectName.Text);
            StatuseText.Text = myTiaPortalEX.CreatProject(ProjectPath.Text, ProjectName.Text);
            //this.Close();
        }
    }
}
