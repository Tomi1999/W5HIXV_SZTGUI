using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV_HFT_2023241.Repository
{
    public class SiteRepository : Repository<Site>, IRepository<Site>
    {
        public SiteRepository(FleetDbContext ctx) : base(ctx)
        {
        }

        public override Site Read(int id)
        {
            return ctx.Sites.FirstOrDefault(t=>t.Id== id);
        }

        public override void Update(Site item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
