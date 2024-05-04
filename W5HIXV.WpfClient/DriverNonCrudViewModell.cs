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
        public RestCollection<Driver> DriversNon { get; set; }

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
               

                ListDriversOver = new RelayCommand(() =>
                {
                    DriversNon = new DriverRestCollection<Driver>(distance, "http://localhost:55762/", "DriverNon/DriversOverValue?value=" );
                });
            }
        }
    }
}
