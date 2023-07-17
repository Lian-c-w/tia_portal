using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using PlcSimADManager;
using System.Windows.Forms;
using FunctionManager;

namespace FormManager
{
    public partial class FormPlcSimAD : Form
    {
        private PlcSimInstance myplc_Instance;
        //private FunctionManager.FunctionManager myFM;
        public FormPlcSimAD()
        {
            //myFM = fm;
            InitializeComponent();            
        }

        private void FormPlcSimAD_Load(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\SIEMENS\Automation\PLCSIMADV\bin\Siemens.Simatic.PlcSim.Advanced.UserInterface.exe");
            MessageText.Text = MessageText.Text + "PLCSIM Advanced  成功启动" + "\r\n";
            try
            {
                myplc_Instance = new PlcSimInstance(Simulation_PLC_Name.Text);
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateInstance_Click(object sender, EventArgs e)
        {
            if (myplc_Instance == null)
            {
                try
                {
                    myplc_Instance = new PlcSimInstance(Simulation_PLC_Name.Text, Simulation_PLC_IP_1.Text, Simulation_PLC_IP_2.Text, Simulation_PLC_IP_3.Text, Simulation_PLC_IP_4.Text);
                    MessageText.Text = MessageText.Text + "实例成功建立" + "\r\n";
                }
                catch (Exception exp)
                {
                    ;
                }
                finally
                {
                    //plc_Instance.Instance.OnOperatingStateChanged += plc_Instance_OnOperatingStateChanged;
                    //plc_Instance.Text = EOperatingState.Off.ToString();
                    //Simulation_PLC_Power_On.Enabled = true;
                    //New_PLC.Enabled = false;

                }
            }
        }

        private void PowerOn_Click(object sender, EventArgs e)//实例上电
        {
            //if(plc_Instance==null)
            //{
            //   // plc_Instance = plc_Instance.GetInstance()[0];
            //}
            try
            {
                myplc_Instance.PowerOnPLCInstance();
                MessageText.Text = MessageText.Text + "PLC上电" + "\r\n";
                //myplc_Instance.myForm = this;
               // myplc_Instance.myTB = MessageText;
                //Thread t = new Thread(myplc_Instance.PowerOnPLCInstance);
                //t.IsBackground = true;
                //t.Start();
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void PowerOFF_Click(object sender, EventArgs e)
        {
            try
            {
                myplc_Instance.PowerOffPLCInstance();
                MessageText.Text = MessageText.Text + "PLC下电" + "\r\n";
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            try
            {
                myplc_Instance.RunPLCInstance();
                MessageText.Text = MessageText.Text + "PLC运行" + "\r\n";
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            try
            {
                myplc_Instance.StopPLCInstance();
                MessageText.Text = MessageText.Text + "PLC停止" + "\r\n";
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void FormPlcSimAD_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //myplc_Instance.DeletInstance ();
            }
            catch (Exception exp)
            {
                ;
            }
        }

        private void DownLoad_Click(object sender, EventArgs e)
        {
            //myFM.myCPU = new StationType();
            //myFM.myCPU.Name = CPUName.Text;
            //myFM.myTB = MessageText;
            //myFM.myForm = this;
            //Thread t = new Thread(myFM.DownLoad);
            //t.IsBackground = true;
            //t.Start();
            //myFM.DownLoad(CPUName.Text);
        }
        /// <summary>
        /// 更新CPU站点名称
        /// </summary>
        /// <param name="info"></param>
        public void UpdateCpuName(string info)
        {
            //CPUName.Text = info;
            Refresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
