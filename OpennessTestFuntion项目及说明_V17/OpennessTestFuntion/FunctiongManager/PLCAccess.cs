using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Siemens.Engineering.Download;
using Siemens.Engineering.Download.Configurations;
using Siemens.Engineering;
using Siemens.Engineering.Online;
using Siemens.Engineering.HW;
using Siemens.Engineering.SW;
using Siemens.Engineering.Connection;
using Siemens.Engineering.Compare;

namespace FunctionManager
{
    public class NetParameter
    {
        public string Modes { get; set; }
        public string PcInterface { get; set; }
        public int Number { get; set; }
        public string TargetInterface { get; set; }
    }
   
    class PLCAccess
    {
        public string StatusText { get; set; }       

        private DownloadProvider GetDownloadProvider(StationType mt,Project project)
        {
            //StationsFunction sf = new StationsFunction();
            Device device = StationsFunction.GetDevice(mt, project);
            if(device!=null)
            {
                return device.DeviceItems[1].GetService<DownloadProvider>();
            }
            return null;
        }
        private OnlineProvider GetOnlineProvider(StationType mt,Project project)
        {
            //StationsFunction sf = new StationsFunction();
            Device device = StationsFunction.GetDevice(mt, project);
            if (device != null)
            {
                return device.DeviceItems[1].GetService<OnlineProvider>();
            }
            return null;
        }
        private IConfiguration GetTargetConfiguration(DownloadProvider dp,NetParameter np)
        {                              
            try
            {
                ConfigurationPcInterface pcInterface = dp.Configuration.Modes.Find(np.Modes).PcInterfaces.Find(np.PcInterface, np.Number);
                return pcInterface.TargetInterfaces[0];
            }
            catch(Exception exp)
            {
                StatusText = exp.Message;
                return null;
            }
        }
        private IConfiguration GetTargetConfiguration(OnlineProvider op, NetParameter np)
        {
            try
            {
                ConfigurationPcInterface pcInterface = op.Configuration.Modes.Find(np.Modes).PcInterfaces.Find(np.PcInterface, np.Number);
                return pcInterface.TargetInterfaces[0];
            }
            catch (Exception exp)
            {
                StatusText = exp.Message;
                return null;
            }
        }

        private static void PreConfigureDownload(DownloadConfiguration downloadConfiguration)
        {
            StopModules stopModules = downloadConfiguration as StopModules;
            if (stopModules != null)
            {
                stopModules.CurrentSelection = StopModulesSelections.StopAll;  // This selection will set PLC into "Stop" mode
                return;
            }
            AlarmTextLibrariesDownload alarmTextLibraries = downloadConfiguration as AlarmTextLibrariesDownload;
            if (alarmTextLibraries != null)
            {
                alarmTextLibraries.CurrentSelection = AlarmTextLibrariesDownloadSelections.ConsistentDownload;
                return;
            }
            BlockBindingPassword blockBindingPassword = downloadConfiguration as BlockBindingPassword;
            if (blockBindingPassword != null)
            {
                SecureString password = new SecureString();  // Get Binding password from a secure location
                string pa = "123456";
                foreach(char c in pa)
                {
                    password.AppendChar(c);
                }
                blockBindingPassword.SetPassword(password);
                return;
            }
            CheckBeforeDownload checkBeforeDownload = downloadConfiguration as CheckBeforeDownload;
            if (checkBeforeDownload != null)
            {
                checkBeforeDownload.Checked = true;
                return;
            }
            ConsistentBlocksDownload consistentBlocksDownload = downloadConfiguration as ConsistentBlocksDownload;
            if (consistentBlocksDownload != null)
            {
                consistentBlocksDownload.CurrentSelection = ConsistentBlocksDownloadSelections.ConsistentDownload;
                return;
            }
            ModuleWriteAccessPassword moduleWriteAccessPassword = downloadConfiguration as ModuleWriteAccessPassword;
            if (moduleWriteAccessPassword != null)
            {
                SecureString password = new SecureString();  // Get PLC protection level password from a secure location
                string pa = "123456";
                foreach (char c in pa)
                {
                    password.AppendChar(c);
                }
                moduleWriteAccessPassword.SetPassword(password);
                return;
            }
            throw new NotSupportedException();  // Exception thrown in the delagate will cancel download
        }
        private static void PostConfigureDownload(DownloadConfiguration downloadConfiguration)
        {
            StartModules startModules = downloadConfiguration as StartModules;
            if (startModules != null)
            {
                startModules.CurrentSelection = StartModulesSelections.StartModule; // Sets PLC in "Run" mode 
            }
        }
        private void SetParameterForOnlineConnection(NetParameter np, OnlineProvider onlineProvider)
        {
            if (onlineProvider != null)
            {
                ConnectionConfiguration configuration = onlineProvider.Configuration;
                ConfigurationMode mode = configuration.Modes.Find(np.Modes);
                ConfigurationPcInterface pcInterface = mode.PcInterfaces.Find(np.PcInterface, np.Number);
                ConfigurationTargetInterface slot = pcInterface.TargetInterfaces.Find(np.TargetInterface);
                configuration.ApplyConfiguration(slot);
            }            
        }

        /// <summary>
        /// 下载功能
        /// </summary>
        /// <param name="CPUName"></param>
        /// <param name="project"></param>
        /// <param name="NetCardName"></param>
        /// <returns></returns>
        public DownloadResult Download(StationType mt, Project project, NetParameter np)
        {
            DownloadProvider downloadProvider = GetDownloadProvider(mt, project);
            IConfiguration targetConfiguration = GetTargetConfiguration(downloadProvider, np);
            DownloadConfigurationDelegate preDownloadDelegate = PreConfigureDownload;
            DownloadConfigurationDelegate postDownloadDelegate = PostConfigureDownload;
            try
            {
                return downloadProvider.Download(targetConfiguration, preDownloadDelegate, 
                       postDownloadDelegate, DownloadOptions.Hardware | DownloadOptions.Software);
            }
            catch(Exception exp)
            {
                StatusText = exp.Message;
                return null;
            }
            
                    
        }
        public void ConnectPLC(StationType mt, Project project, NetParameter np)
        {
            OnlineProvider op = GetOnlineProvider (mt,project);
            SetParameterForOnlineConnection(np, op);
            if (mt.OnLineFlag)
            {
                op.GoOnline();
            }
            else
            {
                op.GoOffline();
            }
        }
        /// <summary>
        /// 在线离线比较
        /// </summary>
        /// <param name="plcSoftware"></param>
        /// <returns></returns>
        public CompareResult ComparePlcToOnlinePlc(StationType mt, Project project, NetParameter np)
        {
            mt.OnLineFlag = true;
            ConnectPLC(mt, project, np);           
            PlcSoftware plcSoftware = CGetSW.GetSW(mt.Name, project);
            if (plcSoftware != null)
            {
                return plcSoftware.CompareToOnline();
            }
            return null;
        }
    }
}
