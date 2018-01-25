using NFCDetectPOC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCDetectPOC.Models
{
    public class NFCDevice : ViewModelBase
    {
        private int _ID;
        private string _DeviceName;
        private string _DeviceAddress;
        private string _DeviceManufac;


        public NFCDevice()
        {

        }
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                NotifyPropertyChanged();
            }
        }
        public string DeviceName
        {
            get
            {
                return _DeviceName;
            }

            set
            {
                _DeviceName = value;
                NotifyPropertyChanged();
            }
        }
        public string DeviceAddress
        {
            get
            {
                return _DeviceAddress;
            }

            set
            {
                _DeviceAddress = value;
                NotifyPropertyChanged();
            }
        }
        public string DeviceManufac
        {
            get
            {
                return _DeviceManufac;
            }

            set
            {
                _DeviceManufac = value;
                NotifyPropertyChanged();
            }
        }
    }
}
