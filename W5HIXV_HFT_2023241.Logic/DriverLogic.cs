using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;

namespace W5HIXV_HFT_2023241.Logic
{
    public class DriverLogic : IDriverLogic
    {
        IRepository<Driver> repo;

        public DriverLogic(IRepository<Driver> repo)
        {
            this.repo = repo;
        }

        public void Create(Driver item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Driver Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Driver> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Driver item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<Driver> DriversOverValue(int value)
        {
            return this.repo.ReadAll().Where(t => t.Distance > value);
        }
    }
}
