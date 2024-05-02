using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class DriverNonCrudViewModell : ObservableRecipient
    {
        public RestCollection<Driver> Drivers { get; set; }

        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set { selectedDriver = value; }
        }

        private string distance;

        public string Distance
        {
            get { return distance; }
            set { distance = value; }
        }

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

            }
        }
    }
}
