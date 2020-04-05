using RetailManagementTool.Data;
using RetailManagementTool.Models.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class ZoneService
    {
        public ZoneService()
        {

        }

        //CREATE
        public bool CreateZone(ZoneCreate model)
        {
            var entity = new Zone()
            {
                ZoneName = model.ZoneName,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Zones.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<ZoneListItem> GetZones()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Zones.Select(
                             e =>
                                  new ZoneListItem
                                  {
                                      ZoneId = e.ZoneId,
                                      ZoneName = e.ZoneName,
                                  }
                                  );

                return query.ToArray();
            }
        }

        //GET BY ID
        public ZoneDetail GetZoneById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Zones.Single(e => e.ZoneId == id);
                return new ZoneDetail
                {
                    ZoneId = entity.ZoneId,
                    ZoneName = entity.ZoneName,
                };
            }
        }

        //UPDATE
        public bool UpdateZone(ZoneEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Zones
                    .Single(e => e.ZoneId == model.ZoneId);

                entity.ZoneName = model.ZoneName;
                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteZone(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Zones.Single(e => e.ZoneId == id);

                ctx.Zones.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
