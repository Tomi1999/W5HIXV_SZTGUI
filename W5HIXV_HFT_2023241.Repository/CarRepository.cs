using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV_HFT_2023241.Repository
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(FleetDbContext ctx) : base(ctx)
        {
        }

        public override Car Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Car item)
        {
            throw new NotImplementedException();
        }
    }
}
