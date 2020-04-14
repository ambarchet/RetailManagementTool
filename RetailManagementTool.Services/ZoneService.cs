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
                ZoneName = model.ZoneName
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

                query.ToList();
                List<ZoneListItem> orderedByName = query.OrderBy(e => e.ZoneName).ToList();
                return orderedByName;
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
        public string DeleteZone(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Zones.Single(e => e.ZoneId == id);

                var service = new ProductService();
                var query = service.GetProductByZone(id);
                if (query.ToList().Count() == 0)
                {
                    try
                    {
                        ctx.Zones.Remove(entity);
                        ctx.SaveChanges();
                        return "Zone successfully deleted";
                    }
                    catch (Exception s)
                    {
                        return s.Message;
                    }
                }
                return "Unable to delete this Zone";
            }
        }
    }
}
