using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV_HFT_2023241.Repository
{
    public class DriverRepository : Repository<Driver>, IRepository<Driver>
    {
        public DriverRepository(FleetDbContext ctx) : base(ctx)
        {
        }

        public override Driver Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Driver item)
        {
            throw new NotImplementedException();
        }
    }
}
