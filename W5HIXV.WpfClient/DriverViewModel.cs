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
    internal class DriverViewModel : ObservableRecipient
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
                    (DeleteDriverCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand CreateDriverCommand { get; set; }

        public ICommand UpdateDriverCommand { get; set; }

        public ICommand DeleteDriverCommand { get; set; }

        public DriverViewModel()
        {
            if (!IsInDesignMode)
            {
                Drivers = new RestCollection<Driver>("http://localhost:55762/", "Driver");
                CreateDriverCommand = new RelayCommand(() =>
                {
                    int id = Drivers.Max(t => t.Id);
                    Drivers.Add(new Driver()
                    {
                        Id = id + 1,
                        Name = SelectedDriver.Name,
                        Distance = SelectedDriver.Distance 

                    });
                }
              );
                DeleteDriverCommand = new RelayCommand(() =>
                {
                    Drivers.Delete(SelectedDriver.Id);
                },
                () =>
                {
                    return SelectedDriver != null;
                }
                );
                UpdateDriverCommand = new RelayCommand(() =>
                {
                    Drivers.Update(SelectedDriver);
                });
            }
        }
    }
}
