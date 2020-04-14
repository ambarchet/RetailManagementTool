using RetailManagementTool.Data;
using RetailManagementTool.Models.Promotion;
using RetailManagementTool.Models.PromotionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class PromotionTypeService
    {
        public PromotionTypeService()
        {

        }

        //CREATE
        public bool CreatePromotionType(PromotionTypeCreate model)
        {
            var entity = new PromotionType()
            {
                Type = model.Type,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PromotionTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<PromotionTypeListItem> GetPromotionTypes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.PromotionTypes.Select(
                             e =>
                                  new PromotionTypeListItem
                                  {
                                      PromotionTypeId = e.PromotionTypeId,
                                      Type = e.Type,
                                  }
                                  );

                query.ToList();
                List<PromotionTypeListItem> orderedByType = query.OrderBy(e => e.Type).ToList();
                return orderedByType;
            }
        }

        //GET BY ID
        public PromotionTypeDetail GetPromotionTypeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PromotionTypes.Single(e => e.PromotionTypeId == id);
                return new PromotionTypeDetail
                {
                    PromotionTypeId = entity.PromotionTypeId,
                    Type = entity.Type,
                };
            }
        }

        //UPDATE
        public bool UpdatePromotionType(PromotionTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PromotionTypes
                    .Single(e => e.PromotionTypeId == model.PromotionTypeId);

                entity.Type = model.Type;
                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public string DeletePromotionType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PromotionTypes.Single(e => e.PromotionTypeId == id);

                var service = new PromotionService();
                var query = service.GetPromotionByPromoType(id);
                if (query.ToList().Count() == 0)
                {
                    try
                    {
                            ctx.PromotionTypes.Remove(entity);
                            ctx.SaveChanges();
                            return "Promotion Type successfullly deleted";
                    }
                    catch (Exception s)
                    {

                        return s.Message;
                    }
                }
                return "Unable to delete this Promotion Type";
            }
        }
    }
}

