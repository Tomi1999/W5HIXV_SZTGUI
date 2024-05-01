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
    internal class DriverNonCrudViewModell : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Driver> Drivers { get; set; }
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
        private string distanceValue;

        public string DistanceValue
        {
            get { return distanceValue; }

            set
            {
                if (value != null)
                {
                    distanceValue = value;
                    OnPropertyChanged();
                    (ListtDriverCommand as RelayCommand).NotifyCanExecuteChanged();
                } 
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

        }
        public ICommand ListtDriverCommand { get; set; }
        public DriverNonCrudViewModell()
        {
            if (!IsInDesignMode)
            {
                Drivers = new RestCollection<Driver>("http://localhost:55762/", "DriverNon");
                ListtDriverCommand = new RelayCommand(() =>
                {
                   //Drivers
                },
                () =>
                {
                    return DistanceValue != null;
                });
            }
        }
    }
}
