using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W5HIXV.WpfClient
{
    class CarwinowViewModel
    {
        public ICommand ListAllCar { get; set; }

        public ICommand CreateCar { get; set; }

        public ICommand ReadCar { get; set; }

        public ICommand UpdateCar { get; set; }

        public ICommand DeleteCar { get; set; }

    }
}
