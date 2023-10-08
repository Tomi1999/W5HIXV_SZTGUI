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
        public DbSet<Cars> Cars { get; set; }
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
            modelBuilder.Entity<Cars>()
                .HasOne(t=>t.Driver)
                .WithOne(t=>t.Site)
                
        }
    }
}
