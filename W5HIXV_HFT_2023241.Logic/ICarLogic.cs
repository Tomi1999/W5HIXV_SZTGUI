using System.Linq;
using W5HIXV_HFT_2023241.Models;
using W5HIXV_HFT_2023241.Repository;

namespace W5HIXV_HFT_2023241.Logic
{
    public interface ICarLogic
    {

        public void Create(Car item);
        public void Delete(int id);
        public Car Read(int id);
        public IQueryable<Car> ReadAll();
        public void Update(Car item);
    }
}