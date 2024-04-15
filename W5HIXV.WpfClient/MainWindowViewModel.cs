using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Car> Cars { get; set; }
        public MainWindowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:55762/", "car");
        }
    }
}
