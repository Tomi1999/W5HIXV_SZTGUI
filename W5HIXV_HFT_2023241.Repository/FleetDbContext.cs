using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV_HFT_2023241.Repository
{
    public class FleetDbContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        

        public FleetDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies()
                .UseInMemoryDatabase("Fleet");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasOne(t=>t.Site)
                .WithMany(t=>t.Drivers);
            modelBuilder.Entity<Car>()
                .HasOne(t => t.Site)
                .WithMany(t => t.Cars);
            var sites = new List<Site>
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
            };
            var cars = new List<Car> 
            {
                new Car()
                {
                    Id = 1,
                    Plate = "ABC123",
                    Brand = "Ivecco",
                    Total_Weith = 3500
                },
                new Car()
                {
                    Id = 2,
                    Plate = "ABB123",
                    Brand = "Ivecco",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 3,
                    Plate = "BBB123",
                    Brand = "Ivecco",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 4,
                    Plate = "BBC123",
                    Brand = "MAN",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 5,
                    Plate = "BBD123",
                    Brand = "MAN",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 6,
                    Plate = "BBE123",
                    Brand = "Renault",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 7,
                    Plate = "BBF123",
                    Brand = "Scania",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 8,
                    Plate = "BBF153",
                    Brand = "Scania",
                    Total_Weith = 7500
                },
                new Car()
                {
                    Id = 9,
                    Plate = "BBF166",
                    Brand = "Renault",
                    Total_Weith = 7500
                }
            };
            var drivers = new List<Driver> 
            {
                new Driver()
                {
                    Id = 1,
                    Name = "John Doe",
                    Distance = 564
                },
                 new Driver()
                {
                    Id = 2,
                    Name = "Johanna Forsner",
                    Distance = 54
                },
                 new Driver()
                {
                    Id = 3,
                    Name = "Bob Dilan",
                    Distance = 5645
                },
                 new Driver()
                {
                    Id = 4,
                    Name = "Jimi Hendrix",
                    Distance = 236
                },
                 new Driver()
                {
                    Id = 5,
                    Name = "Kurt Cobain",
                    Distance = 1456
                },
                 new Driver()
                {
                    Id = 6,
                    Name = "Machine Gun Kelly",
                    Distance = 1564
                },
                 new Driver()
                {
                    Id = 7,
                    Name = "Eminem",
                    Distance = 2564
                },
                 new Driver()
                {
                    Id = 8,
                    Name = "Mike Tyson",
                    Distance = 9564
                },
                  new Driver()
                {
                    Id = 9,
                    Name = "Don Corleone",
                    Distance = 4564
                },
                
            };


        }
    }
}
