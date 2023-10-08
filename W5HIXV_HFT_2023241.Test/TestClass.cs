using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
                 
                }.AsQueryable());
            carLogic = new CarLogic(carMock.Object);
        }
    }
}
