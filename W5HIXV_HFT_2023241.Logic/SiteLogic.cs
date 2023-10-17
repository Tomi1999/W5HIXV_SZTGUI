using System;
using System.Collections.Generic;
using System.Linq;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;

namespace W5HIXV_HFT_2023241.Logic
{
    public class SiteLogic : ISiteLogic
    {
        IRepository<Site> repo;

        public SiteLogic(IRepository<Site> repo)
        {
            this.repo = repo;
        }

        public void Create(Site item)
        {
            this.repo.Create(item); 
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Site Read(int id)
        {
            return this.repo.Read(id);
        }

        public void Update(Site item) 
        {
            this.repo.Update(item); 
        }

        public IQueryable<Site> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public IEnumerable<Car> CarsInSite(int id)
        {
            return this.repo.Read(id).Cars;
        }

        public IEnumerable<Driver> DriverInSite(int id)
        {
            return this.repo.Read(id).Drivers;
        }
    }
}
