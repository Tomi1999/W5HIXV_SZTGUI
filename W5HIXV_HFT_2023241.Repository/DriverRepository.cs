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
            return ctx.Drivers.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Driver item)
        {
            var old = this.Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
