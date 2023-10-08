using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using W5HIXV_HFT_2023241.Logic;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace W5HIXV_HFT_2023241.Test
{
    [TestFixture]
    public class TestClass
    {
        CarLogic carLogic;
        DriverLogic driverLogic;
        SiteLogic siteLogic;
        Mock<IRepository<Car>> carMock;
        Mock<IRepository<Driver>> driverMock;
        Mock<IRepository<Site>> siteMock;
        
        [SetUp]
        public void InitCar()
        {
            carMock = new Mock<IRepository<Car>>();
            carMock.Setup(m => m.ReadAll()).Returns(new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Plate = "ABC123",
                    Brand = "Ivecco",
                    Total_Weith = 3500,
                    DriverId = 1,
                    SiteId = 1
                },
                new Car()
                {
                    Id = 2,
                    Plate = "ABB123",
                    Brand = "Ivecco",
                    Total_Weith = 7500,
                    DriverId = 2,
                    SiteId = 1
                },
                new Car()
                {
                    Id = 3,
                    Plate = "BBB123",
                    Brand = "Ivecco",
                    Total_Weith = 7500,
                    DriverId = 3,
                    SiteId = 1
                },
                new Car()
                {
                    Id = 4,
                    Plate = "BBC123",
                    Brand = "MAN",
                    Total_Weith = 7500,
                    DriverId = 4,
                    SiteId = 2
                },
                new Car()
                {
                    Id = 5,
                    Plate = "BBD123",
                    Brand = "MAN",
                    Total_Weith = 7500,
                    DriverId = 5,
                    SiteId = 2
                },
                new Car()
                {
                    Id = 6,
                    Plate = "BBE123",
                    Brand = "Renault",
                    Total_Weith = 7500,
                    DriverId = 6,
                    SiteId = 2
                },
                new Car()
                {
                    Id = 7,
                    Plate = "BBF123",
                    Brand = "Scania",
                    Total_Weith = 7500,
                    DriverId = 7,
                    SiteId = 3
                },
                new Car()
                {
                    Id = 8,
                    Plate = "BBF153",
                    Brand = "Scania",
                    Total_Weith = 7500,
                    DriverId = 8,
                    SiteId = 3
                },
                new Car()
                {
                    Id = 9,
                    Plate = "BBF166",
                    Brand = "Renault",
                    Total_Weith = 7500,
                    DriverId = 9,
                    SiteId = 3
                }
            }.AsQueryable());
            carLogic = new CarLogic(carMock.Object);
        }
        [SetUp]
        public void InitSite()
        {
            siteMock = new Mock<IRepository<Site>>();
            siteMock.Setup(m => m.ReadAll()).Returns(new List<Site>()
            {
               new Site()
               {
                    Id = 1,
                    Name = "Big",
                    Address = "Budapest, Europa u. 6, 1239",

               },
               new Site()
               {
                    Id = 2,
                    Name = "Medium",
                    Address = "Budapest, Nagykorösi út 351, 1239",

               },
               new Site()
               {   
                    Id = 3,
                    Name = "Smal",
                    Address = "Budapest, Könyves Kálmán krt. 13, 1097",

               }
            }.AsQueryable());
            siteLogic = new SiteLogic(siteMock.Object);
        }
        [SetUp]
        public void InitDriver()
        {
            driverMock = new Mock<IRepository<Driver>>();
            driverMock.Setup(m => m.ReadAll()).Returns(new List<Driver>()
            {
               new Driver()
        {
            Id = 1,
            Name = "John Doe",
            Distance = 564,
            SiteId = 1
        },
         new Driver()
        {
            Id = 2,
            Name = "Johanna Forsner",
            Distance = 54,
            SiteId = 1
        },
         new Driver()
        {
            Id = 3,
            Name = "Bob Dilan",
            Distance = 5645,
            SiteId = 1
        },
         new Driver()
        {
            Id = 4,
            Name = "Jimi Hendrix",
            Distance = 236,
            SiteId = 2
        },
         new Driver()
        {
            Id = 5,
            Name = "Kurt Cobain",
            Distance = 1456,
            SiteId = 2
        },
         new Driver()
        {
            Id = 6,
            Name = "Machine Gun Kelly",
            Distance = 1564,
            SiteId = 2
        },
         new Driver()
        {
            Id = 7,
            Name = "Eminem",
            Distance = 2564,
            SiteId = 3
        },
         new Driver()
        {
            Id = 8,
            Name = "Mike Tyson",
            Distance = 9564,
            SiteId = 3
        },
          new Driver()
        {
            Id = 9,
            Name = "Don Corleone",
            Distance = 4564,
            SiteId = 3
        }
            }.AsQueryable());
            driverLogic = new DriverLogic(driverMock.Object);
        }

        [Test]
        public void CreateMethodTest()
        {
            Car sil = new Car { Id = 10, Brand = "Ifa", Total_Weith = 7500, Plate = "AAAB711" };
            carLogic.Create(new Car { Id = 10, Brand = "Ifa", Total_Weith = 7500, Plate = "AAAB711"});
            var ifa = carLogic.ReadAll().Where(t => t.Id == 10);
            foreach (var item in ifa.GetType().GetProperties())
            {
                foreach (var t in sil.GetType().GetProperties())
                {
                    Assert.That(item == t);
                }
            }
        }
    
    }
}
