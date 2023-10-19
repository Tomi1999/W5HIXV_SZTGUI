using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.Write("Enter Site name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Site address: ");
                string addr = Console.ReadLine();
                rest.Post(new Site()
                {
                    Id = int.Parse(id),
                    Name = name,
                    Address = addr,
                }, "swagger");
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

                }, "swagger") ;
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

                }, "swagger");

            }
        }
        static void List(string entity)
        {
            if (entity == "Site")
            {
                List<Site> companies = rest.Get<Site>("site");
                foreach (var item in companies)
                {
                    Console.WriteLine(item.Id + ": " + item.Name+"-"+item.Address);
                }
            }
            else if (entity == "Car")
            {
                List<Car> places = rest.Get<Car>("car");
                foreach (var item in places)
                {
                    Console.WriteLine(item.Id + ": " + item.Plate+"-"+item.Brand);
                }
            }
            else if (entity == "Driver")
            {
                List<Driver> disches = rest.Get<Driver>("driver");
                foreach (var item in disches)
                {
                    Console.WriteLine(item.Id + ": " + item.Name + "-" + item.Distance);
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
                Console.WriteLine("address - write ad, Site name - write sn");
                string up = Console.ReadLine();
                Console.WriteLine("please write it");
                string input = Console.ReadLine();
                if (up == "ad")
                {
                    one.Address = input;
                }
                else if (up == "cn")
                {
                    one.Name = input;
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
                Console.Write("Enter the id of dthe driver: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "driver");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:55762/", "swagger");
            var SiteMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Site"))
               .Add("Create", () => Create("Site"))
               .Add("Delete", () => Delete("Site"))
               .Add("Update", () => Update("Site"))
               .Add("Exit", ConsoleMenu.Close);
            var CarMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);
            var DriverMenu = new ConsoleMenu(args, level: 1)
              .Add("List", () => List("Driver"))
              .Add("Create", () => Create("Driver"))
              .Add("Delete", () => Delete("Driver"))
              .Add("Update", () => Update("Driver"))
              .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Site", () => SiteMenu.Show())
                .Add("Car", () => CarMenu.Show())
                .Add("Driver", () => DriverMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
                menu.Show();

        }
    }
}
