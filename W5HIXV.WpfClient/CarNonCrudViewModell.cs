using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    public class CarNonCrudViewModell : ObservableRecipient
    {

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        private string nonCrudValue;

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
        public CarNonCrudViewModell()
        {
            if (!IsInDesignMode)
            {

            }  
        }
    }
}
