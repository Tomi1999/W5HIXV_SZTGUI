using Moq;
using NUnit.Framework;
using System;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;

namespace W5HIXV_HFT_2023241.Test
{
    [TestFixture]
    public class TestClass
    {
        CarRepository carRepo;
        DriverRepository driverRepo;
        SiteRepository siteRepo;
        Mock<IRepository<Car>> carMock;
        Mock<IRepository<Driver>> driverMock;
        Mock<IRepository<Site>> siteMock;
    }
}
