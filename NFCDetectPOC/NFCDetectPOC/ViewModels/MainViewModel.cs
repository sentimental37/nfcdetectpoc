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
using NFCDetectPOC.Helpers;

namespace NFCDetectPOC.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Properties
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
            this.DialogService = new MvvmDialogs.DialogService();
        }

        #endregion

        #region Methods
        private void OnRefreshDevices()
        {
            try
            {
                DevicesList = NFCWMQHelper.GetConnectedDevices();
                NotifyPropertyChanged("DevicesCount");
                if (DevicesList.Count == 0)
                {
                    DialogService.ShowMessageBox(this, "No Device Connected.Try Again after connecting a device.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void OnExitApp()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }
        #endregion

        #region Commands

        public ICommand RefreshDevices { get { return new RelayCommand(OnRefreshDevices); } }

        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp); } }

        #endregion
    }
}
