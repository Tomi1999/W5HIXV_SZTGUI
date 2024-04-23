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

        public ICommand CreateCarCommand { get; set; }  
        public ICommand DeleteCarCommand { get; set; }  
        public ICommand UpdateCarCommand { get; set; }  
        public RestCollection<Car> Cars { get; set; }
        public MainWindowViewModel()
        {
            List<string> models = new List<string>() {"Car", "Driver", "Site" };
            Cars = new RestCollection<Car>("http://localhost:55762/", "car");
        }
    }
}
