using System;
using System.Windows.Forms;
using Siemens.Simatic.Simulation.Runtime;
using FunctionManager;


namespace PlcSimADManager
{
    public class PlcSimADManager
    {
    }
    public class PlcSimInstance
    {
        IInstance instance;
        public Form myForm { get; set; }
        public TextBox myTB { get; set; }
        private delegate void deleTextBoxAdd(string st);//添加文字的函数代理

        string[] ip = new string[4];
        public IInstance Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public PlcSimInstance(string Instancename, string ip1, string ip2, string ip3, string ip4)
        {
            try
            {
                instance = SimulationRuntimeManager.RegisterInstance(Instancename);

            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
            finally
            {
                instance.IsSendSyncEventInDefaultModeEnabled = false;
                instance.CommunicationInterface = ECommunicationInterface.TCPIP;
                instance.OnSyncPointReached += instance_OnSyncPointReached;
                ip[0] = ip1;
                ip[1] = ip2;
                ip[2] = ip3;
                ip[3] = ip4;
                string aaaaa = instance.ControllerName;
            }
        }

        public PlcSimInstance(string InstanceName)
        {
            try
            {
                instance = SimulationRuntimeManager.CreateInterface(InstanceName);

            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
        }

        void instance_OnSyncPointReached(IInstance in_Sender, ERuntimeErrorCode in_ErrorCode,
                   DateTime in_DateTime, UInt32 in_PipId, Int64 in_TimeSinceSameSyncPoint, Int64 in_TimeSinceAnySyncPoint, UInt32 in_SyncPointCount)
        {
            //Form1.valve_to_plc_1 = instance.OutputArea.ReadBit(0, 0);
            //Form1.valve_to_plc_2 = instance.OutputArea.ReadBit(0, 1);
            //instance.InputArea.WriteBit(0, 0, Form1.plc_to_valve_1);
            //instance.InputArea.WriteBit(0, 1, Form1.plc_to_valve_2);
        }
        public void PowerOnPLCInstance()
        {
            string ip_temp;
            ip_temp = ip[0] + "." + ip[1] + "." + ip[2] + "." + ip[3];
            SIPSuite4 instanceIP = new SIPSuite4(ip_temp, "255.255.255.0", "0.0.0.0");
            deleTextBoxAdd deletextboxadd = new deleTextBoxAdd(TextBoxAdd);
            try
            {
                instance.PowerOn(60000);
                instance.SetIPSuite(0, instanceIP, true);
                myForm.Invoke(deletextboxadd, "PLC成功上电");
            }
            catch (SimulationRuntimeException ex)
            {
                myForm.Invoke(deletextboxadd, "PLC上电不成功");
                throw ex;
            }

        }

        public void PowerOffPLCInstance()
        {
            try
            {
                instance.PowerOff(60000);
            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
        }


        public void RunPLCInstance()
        {

            try
            {
                instance.Run(60000);
            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
        }

        public void StopPLCInstance()
        {
            try
            {
                instance.Stop(60000);
            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
        }
        public SInstanceInfo[] GetInstance()
        {
            try
            {
                return SimulationRuntimeManager.RegisteredInstanceInfo;               
            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
        }
        public void DeletInstance()
        {
            try
            {
                instance.UnregisterInstance();
             
            }
            catch (SimulationRuntimeException ex)
            {
                throw ex;
            }
        }
        private void TextBoxAdd(string st)
        {
            myTB.Text = myTB.Text + st + "\r\n";
        }
        
    }
}
