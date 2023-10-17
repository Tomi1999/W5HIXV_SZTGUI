using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;

namespace W5HIXV_HFT_2023241.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repo;
        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public void Create(Car item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Car Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Car item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<Car> CarsOverTW(int weith)
        {
            return this.repo.ReadAll().Where(t => t.Total_Weith > weith);
        }

        public IEnumerable<Car> GetBrands(string brand)
        {
            return this.repo.ReadAll().Where(t => t.Brand == brand);
        }
    }
}
