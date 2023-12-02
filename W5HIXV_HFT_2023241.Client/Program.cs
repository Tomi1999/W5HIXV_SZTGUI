using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Site")
            {
                Console.WriteLine("Enter the Id:");
                string id = Console.ReadLine();
                Console.Write("Enter Site size: ");
                string name = Console.ReadLine();
                Console.Write("Enter Site address: ");
                string addr = Console.ReadLine();
                rest.Post(new Site()
                {
                    Id = int.Parse(id),
                    Size = name,
                    Address = addr,
                }, "site");
            }
            else if (entity == "Car")
            {
                Console.WriteLine("Enter the Id:");
                string id = Console.ReadLine();
                Console.Write("Enter Plate number: ");
                string plate = Console.ReadLine();
                Console.Write("Enter Brand: ");
                string bran = Console.ReadLine();
                Console.Write("Enter the weith of the car: ");
                string wt = Console.ReadLine();
                Console.Write("Enter the id of the site: ");
                string site = Console.ReadLine();
                Console.Write("Enter the id of the driver: ");
                string driv = Console.ReadLine();
                rest.Post(new Car()
                {
                    Id = int.Parse(id),
                    Plate = plate,
                    Brand = bran,
                    Total_Weith = int.Parse(wt),
                    DriverId = int.Parse(site),
                    SiteId = int.Parse(driv)

                }, "car") ;
            }
            else if (entity == "Driver")
            {
                Console.WriteLine("Enter the Id:");
                string id = Console.ReadLine();
                Console.Write("Enter Driver name: ");
                string name = Console.ReadLine();
                Console.Write("Enter distance: ");
                string dis = Console.ReadLine();
                Console.Write("Enter the id of the site: ");
                string site = Console.ReadLine();

                rest.Post(new Driver()
                {
                    Id = int.Parse(id),
                    Name = name,
                    Distance = int.Parse(dis),
                    SiteId = int.Parse(site)

                }, "driver");

            }
           
        }
        static void List(string entity)
        {
            if (entity == "Site")
            {
                List<Site> sites = rest.Get<Site>("site");
                foreach (var item in sites)
                {
                    Console.WriteLine(item.Id + ": " + item.Size+"-"+item.Address);
                }
            }
            else if (entity == "Car")
            {
                List<Car> cars = rest.Get<Car>("car");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Plate+"-"+item.Brand);
                }
            }
            else if (entity == "Driver")
            {
                List<Driver> drivers = rest.Get<Driver>("driver");
                foreach (var item in drivers)
                {
                    Console.WriteLine(item.Id + ": " + item.Name + "-" + item.Distance);
                }
            }

            else if (entity == "SiteNonA")
            {
                Console.WriteLine("Enter the sight's size");
                string id = Console.ReadLine();
                List<Site> cars = rest.Get<Site>($"SiteNon/SitesSize?size={id}");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Size + "-" + item.Address);
                }
            }
            else if (entity == "SiteNonB")
            {
                Console.WriteLine("Enter the sight's city");
                string id = Console.ReadLine();
                List<Site> cars = rest.Get<Site>($"SiteNon/SiteInCity?city={id}");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Size + "-" + item.Address);
                }
            }
            else if (entity == "CarNonA")
            {
                Console.WriteLine("Enter the weith");
                int id = int.Parse(Console.ReadLine());
                List<Car> cars = rest.Get<Car>($"CarNon/CarsOverTW?weith={id}");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Plate + "-" + item.Brand);
                }
            }
            else if (entity == "CarNonB")
            {
                Console.WriteLine("Enter the brand");
                string id = Console.ReadLine();
                List<Car> cars = rest.Get<Car>($"CarNon/GetBrands?brand={id}");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Plate + "-" + item.Brand);
                }
            }
            else if (entity == "DrivNon")
            {
                Console.WriteLine("Enter the distance");
                int id = int.Parse(Console.ReadLine());
                List<Driver> cars = rest.Get<Driver>($"DriverNon/DriversOverValue?value={id}");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Id + ": " + item.Name + "-" + item.Distance + "Km");
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Site")
            {
                Console.Write("Enter site's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Site one = rest.Get<Site>(id, "site");
                rest.Delete(id, "site");
                Console.WriteLine("What do you want to change? write the following");
                Console.WriteLine("address - write ad, Site size - write si");
                string up = Console.ReadLine();
                Console.WriteLine("please write it");
                string input = Console.ReadLine();
                if (up == "ad")
                {
                    one.Address = input;
                }
                else if (up == "cn")
                {
                    one.Size = input;
                }
                rest.Post(one, "site");
            }
            else if (entity == "Car")
            {
                Console.Write("Enter car's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Car one = rest.Get<Car>(id, "car");
                Console.WriteLine("What is the new plate number?");
                string input = Console.ReadLine();
                rest.Delete(id, "car");
                one.Plate = input;
                rest.Post(one, "car");
            }
            else if (entity == "Driver")
            {
                Console.Write("Enter driver's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Driver one = rest.Get<Driver>(id, "driver");
                Console.WriteLine("What is the new distance?");
                string input = Console.ReadLine();
                rest.Delete(id, "driver");
                one.Distance = int.Parse(input);
                rest.Post(one, "driver");

            }
        }
        static void Delete(string entity)
        {
            if (entity == "Site")
            {
                Console.Write("Enter Site's Id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "site");
            }
            else if (entity == "Car")
            {
                Console.Write("Enter car id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "car");
            }
            else if (entity == "Driver")
            {
                Console.Write("Enter the id of the driver: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "driver");
            }
        }
        static void Read(string entity)
        {
            if (entity == "Site")
            {
                int id = 0;
                Console.WriteLine("Enter Site's Id:");
                try
                {
                    id = int.Parse(Console.ReadLine());
                    var site = rest.Get<Site>(id, "site");
                    Console.WriteLine($"({site.Id}) {site.Size} - {site.Address}");
                    Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid Input");
                }

            }
            else if (entity == "Car")
            {
                int id = 0;
                Console.WriteLine("Enter Car's Id:");
                try
                {
                    id = int.Parse(Console.ReadLine());
                    var car = rest.Get<Car>(id, "car");
                    Console.WriteLine($"({car.Id}) {car.Brand} - {car.Plate}");
                    Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid Input");
                }
                
               
                
            }
            else if (entity == "Driver")
            {
                int id = 0;
                Console.WriteLine("Enter Driver's Id:");
                try
                {
                    id = int.Parse(Console.ReadLine());
                    var site = rest.Get<Driver>(id, "driver");
                    Console.WriteLine($"({site.Id}) {site.Name} - {site.Distance}");
                    Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid Input");
                }

            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:5000/", "swagger");
            var SiteMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Site"))
               .Add("Create", () => Create("Site"))
               .Add("Get an element", ()=> Read("Site"))
               .Add("Delete", () => Delete("Site"))
               .Add("Update", () => Update("Site"))
               .Add("Exit", ConsoleMenu.Close);
            var CarMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Get an element", () => Read("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);
            var DriverMenu = new ConsoleMenu(args, level: 1)
              .Add("List", () => List("Driver"))
              .Add("Create", () => Create("Driver"))
              .Add("Get an element", () => Read("Driver"))
              .Add("Delete", () => Delete("Driver"))
              .Add("Update", () => Update("Driver"))
              .Add("Exit", ConsoleMenu.Close);
            var NonCrudS = new ConsoleMenu(args, level: 1)
                .Add("Size", () => List("SiteNonA"))
                .Add("City", ()=>List("SiteNonB"))
                .Add("Exit", ConsoleMenu.Close);
            var NonCrudC = new ConsoleMenu(args, level: 1)
                .Add("Cars over total weith", () => List("CarNonA"))
                .Add("Get cars from brand", () => List("CarNonB"))
                .Add("Exit", ConsoleMenu.Close);
            var NonCrudD = new ConsoleMenu(args, level: 1)
                .Add("Drivers over distance", () => List("DrivNon"))
                .Add("Exit", ConsoleMenu.Close);



            var menu = new ConsoleMenu(args, level: 0)
                .Add("Site", () => SiteMenu.Show())
                .Add("Car", () => CarMenu.Show())
                .Add("Driver", () => DriverMenu.Show())
                .Add("Non crud site", ()=> NonCrudS.Show())
                .Add("Non crud car", ()=> NonCrudC.Show())
                .Add("Non crud driver", ()=> NonCrudD.Show())
                .Add("Exit", ConsoleMenu.Close);
                menu.Show();

        }
    }
}
