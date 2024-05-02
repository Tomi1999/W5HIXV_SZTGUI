using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    public class MainWindowViewModel
    {
        public ICommand OpenCarCommand { get; set; }  
        public ICommand OpenDriverCommand { get; set; }  
        public ICommand OpenSiteCommand { get; set; }
        public ICommand OpenCarNonCommand { get; set; }
        public ICommand OpenDriverNonCommand { get; set; }
        public ICommand OpenSiteNonCommand { get; set; }

        private CarWindow cw;
        private DriverWindow driverWindow;
        private SiteWindow siteWindow;
        private DriverNonCrudWindow dnonCrudWindow;
        
        public MainWindowViewModel()
        {
            OpenCarCommand = new RelayCommand(() => {
                cw = new CarWindow();
                cw.Show();
            });
            OpenDriverCommand = new RelayCommand(() => {
                driverWindow = new DriverWindow();
                driverWindow.Show();
            });
            OpenSiteCommand = new RelayCommand(() => {
                siteWindow = new SiteWindow();
                siteWindow.Show();
            });
            OpenDriverNonCommand = new RelayCommand(() =>
            {
                dnonCrudWindow = new DriverNonCrudWindow(); 
                dnonCrudWindow.Show();
            });

        }

        
       
    }
}
