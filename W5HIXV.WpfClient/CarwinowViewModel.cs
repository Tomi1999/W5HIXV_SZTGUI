using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    public class CarwinowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Car> Cars { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set 
            {
                if (value != null)
                {
                    selectedCar = value;
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public ICommand CreateCarCommand { get; set; }

        public ICommand UpdateCarCommand { get; set; }

        public ICommand DeleteCarCommand { get; set; }

        public CarwinowViewModel()
        {
            if (!IsInDesignMode) 
            {
                Cars = new RestCollection<Car>("http://localhost:55762/", "Car");
                CreateCarCommand = new RelayCommand(() =>
                {
                    int id = Cars.Max(t=>t.Id);
                    Cars.Add(new Car()
                    {
                        Id = id + 1,
                        Plate = SelectedCar.Plate,
                        Brand = SelectedCar.Brand,
                        Total_Weith = SelectedCar.Total_Weith,

                    });
                }
                );
                DeleteCarCommand = new RelayCommand(() =>
                {
                    Cars.Delete(SelectedCar.Id);
                },
                () =>
                {
                    return SelectedCar != null;
                }
                );
                UpdateCarCommand = new RelayCommand(() =>
                {
                    Car carNew = selectedCar;
                    Cars.Delete(selectedCar.Id);
                    Cars.Add(carNew);
                },
                () =>
                {
                    return SelectedCar != null;
                });
            }
        }

    }
}
