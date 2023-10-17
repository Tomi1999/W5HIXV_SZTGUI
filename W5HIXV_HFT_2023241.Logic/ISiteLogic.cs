using System.Linq;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;

namespace W5HIXV_HFT_2023241.Logic
{
    public interface ISiteLogic
    {

        public void Create(Site item);
        public void Delete(int id);
        public Site Read(int id);
        public IQueryable<Site> ReadAll();
        public void Update(Site item);
        public IQueryable<Car> CarsInSite(Site a);
        public IQueryable<Driver> DriverInSite(Site a);
    }
}