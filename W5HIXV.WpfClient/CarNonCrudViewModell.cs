using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using W5HIXV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace W5HIXV.WpfClient
{
    public class CarNonCrudViewModell : ObservableRecipient
    {
        JSonDownloader downloader = new JSonDownloader("http://localhost:55762/");


        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        private string nonCrudValue;
        public List<Car> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        public string NonCrudValue
        {
			get { return nonCrudValue; }
			set
            {
                if (value != null)
                {
                    nonCrudValue = value;
                    OnPropertyChanged();
                    
                }
            }
		}
        private List<Car> cars { get; set; }

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

        public ICommand GetBrandsCommand { get; set; }

        public ICommand OverTWCommand { get; set; }

        public CarNonCrudViewModell()
        {
            if (!IsInDesignMode)
            {
                
                GetBrandsCommand = new RelayCommand(async () =>
                {
                    var downloadedCars = await downloader.Download<Car>("CarNon/GetBrands?brand="+NonCrudValue);
                    Cars = downloadedCars;
                });
                OverTWCommand = new RelayCommand(async () =>
                {
                    var downloadedCars = await downloader.Download<Car>("CarNon/CarsOverTW?weith=" + NonCrudValue);
                    Cars = downloadedCars;

                });
            }  
        }
    }

    
}
