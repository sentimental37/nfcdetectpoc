using MvvmDialogs;
using log4net;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Input;
using System.Xml.Linq;
using NFCDetectPOC.Views;
using NFCDetectPOC.Utils;
using NFCDetectPOC.Models;

namespace NFCDetectPOC.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Parameters
        private readonly IDialogService DialogService;
        List<NFCDevice> devicesList = new List<NFCDevice>();

        /// <summary>
        /// Title of the application, as displayed in the top bar of the window
        /// </summary>
        public string Title
        {
            get { return "NFCDetectPOC"; }
        }
        public int DevicesCount
        {
            get
            {
                return DevicesList.Count;
            }
        }
        public List<NFCDevice> DevicesList
        {
            get
            {
                if (devicesList == null)
                    devicesList = new List<NFCDevice>();
                return devicesList;
            }
            set
            {
                devicesList = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            // DialogService is used to handle dialogs
            this.DialogService = new MvvmDialogs.DialogService();
            devicesList.Add(new NFCDevice() { ID = 1, DeviceName = "Device1", DeviceManufac = "VISHAL", DeviceAddress = "8908080" });
            devicesList.Add(new NFCDevice() { ID = 2, DeviceName = "Device2", DeviceManufac = "VISHAL", DeviceAddress = "8908080" });
            devicesList.Add(new NFCDevice() { ID = 3, DeviceName = "Device3", DeviceManufac = "VISHAL", DeviceAddress = "8908080" });


        }

        #endregion

        #region Methods

        #endregion

        #region Commands

        public ICommand RefreshDevices { get { return new RelayCommand(OnRefreshDevices); } }

        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp); } }


        private void OnRefreshDevices()
        {
            // TODO
        }

        private void OnExitApp()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }
        #endregion

        #region Events

        #endregion
    }
}
