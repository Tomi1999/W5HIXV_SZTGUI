using System.Collections.Generic;
using System.Linq;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV_HFT_2023241.Logic
{
    public interface IDriverLogic
    {
        public void Create(Driver item);
        public void Delete(int id);
        public Driver Read(int id);
        public IQueryable<Driver> ReadAll();
        public void Update(Driver item);
        public IEnumerable<Driver> DriversOverValue(int vatue);
    }
}