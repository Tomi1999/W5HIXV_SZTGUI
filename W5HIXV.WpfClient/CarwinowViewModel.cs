using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    internal class CarwinowViewModel
    {
        public Grid Grid { get; set; } 
        public ListBox ListBox { get; set; }   
        public Button LiastAll { get; set; }    

        public RestCollection<Car> Cars { get; set; } 
        
        public ICommand ListAllCar { get; set; }

        public ICommand CreateCar { get; set; }

        public ICommand ReadCar { get; set; }

        public ICommand UpdateCar { get; set; }

        public ICommand DeleteCar { get; set; }

        public CarwinowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:55762/", "car");
            Grid = new Grid();
            LiastAll = new Button(); 
            ListBox = new ListBox();
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(LiastAll, 0);
            LiastAll.Height = 72;
            LiastAll.Content = "List All";
            LiastAll.FontSize = 24;
            LiastAll.Margin = new Thickness(0, 0, 0, 0);
            LiastAll.Command = ListAllCar;
            Grid.Children.Add(LiastAll);
            
            ListAllCar = new RelayCommand(() => 
            {
                ListBox.ItemsSource = Cars;
                Grid.SetColumn(ListBox, 1);
                Grid.Children.Add(ListBox);
            });
            
        }

    }
}
