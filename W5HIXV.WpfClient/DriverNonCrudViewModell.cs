using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    public class DriverNonCrudViewModell : ObservableRecipient
    {
        private JSonDownloader downloader = new JSonDownloader("http://localhost:55762/");
        private List<Driver> driversNon;

        public List<Driver> DriversNon
        {
            get { return driversNon; }
            set
            {
                driversNon = value;
                OnPropertyChanged(nameof(DriversNon)); 
            }
        }

        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set 
            {
                if (value != null)
                {
                    selectedDriver = value;
                    OnPropertyChanged();

                }
            }
        }

        private string distance;

        public string Distance
        {
            get { return distance; }
            set 
            {
                if (value != null)
                {
                    distance = value;
                    OnPropertyChanged();
                   
                }
            }
        }

        public ICommand ListDriversOver { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public DriverNonCrudViewModell()
        {
            
            if (!IsInDesignMode)
            {
               

                ListDriversOver = new RelayCommand(async () =>
                {
                    var drivers = await downloader.Download<Driver>("DriverNon/DriversOverValue?value="+Distance);
                    DriversNon = drivers;
                });
            }
        }
    }
}
