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
using FileManager;

namespace FormManager
{
    public partial class AddStations : Form
    {
        //FunctionManager.FunctionManager myHd;

        StationType myCPU;
        StationType myDrive;
        StationType myHMI;
        public AddStations()
        {
            //myHd = hd;
            
           
            myCPU = new StationType();
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            //myCPU.Name = dName.Text;
            //myCPU.OderNo = OrderNo.Text;
            //myCPU.Version = Firmware.Text;
            //myHd.AddStationCPU(myCPU);
            //StatusMessage.Text = myHd.StatusText;
            //myDrive = new MasterType();
            //myDrive.Name = "HMIName";
            //myDrive.OderNo = "6AV2 124-0JC01-0AX0";
            //myDrive.Version = "15.0.0.0";
            //myHd.AddMasterModule(myDrive);

        }

        private void AddModules_Click(object sender, EventArgs e)
        {
            myCPU.Name = dName.Text;
            myCPU.OderNo = OrderNo.Text;
            myCPU.Version = Firmware.Text;

            ExcelManager em = new ExcelManager();
            //em.GetData();
            Moduletype mt = new Moduletype();
            try
            {
                for (int i = 1; i < em.myDT.Rows.Count; i++)
                {
                    string aa = em.myDT.Rows[i][0].ToString();
                    mt.slotNo = Convert.ToInt32(aa);
                    mt.OderNo = em.myDT.Rows[i][1].ToString();
                    mt.Name = em.myDT.Rows[i][2].ToString();
                    mt.Version = em.myDT.Rows[i][3].ToString();
                    //myHd.AddStationModule(myCPU, mt);
                }
            }
            catch(Exception exp)
            {
                ;
            }
            //em.myDT;
        }

        private void AddIOStation_Click(object sender, EventArgs e)
        {
            ExcelManager em = new ExcelManager();
            //em.GetData();
            //Moduletype mt = new Moduletype();
            try
            {
                //Add stations
                for(int i=0;i<em.myDS.Tables.Count;i++)
                {
                    StationType infa = new StationType();
                    infa.Name = em.myDS.Tables[i].TableName;
                    infa.OderNo = em.myDS.Tables[i].Rows[1][1].ToString();
                    infa.Version = em.myDS.Tables[i].Rows[1][3].ToString();
                    //myHd.AddMasterModule(infa);
                    //Add io modules
                    for(int j=2; j< em.myDS.Tables[i].Rows.Count;j++)
                    {
                        Moduletype mt = new Moduletype();
                        string aa = em.myDS.Tables[i].Rows[j][0].ToString();
                        mt.slotNo = Convert.ToInt32(aa);
                        mt.OderNo = em.myDS.Tables[i].Rows[j][1].ToString();
                        mt.Name = em.myDS.Tables[i].Rows[j][2].ToString();
                        mt.Version = em.myDS.Tables[i].Rows[j][3].ToString();
                        //myHd.AddStationModule(infa,mt);
                    }

                }
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void AddV90_Click(object sender, EventArgs e)
        {
            //myHd.AddMasterModule(myDrive)
        }
    }
}
