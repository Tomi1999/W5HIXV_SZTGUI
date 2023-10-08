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
                    Id = 2,
                    Name = "Smal",
                    Address = "Budapest, Könyves Kálmán krt. 13, 1097",

                }
            };
                
        }
    }
}
