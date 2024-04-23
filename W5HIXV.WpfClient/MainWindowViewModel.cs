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
        
    }
}
