using RetailManagementTool.Data;
using RetailManagementTool.Models.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class PromotionService
    {
        public PromotionService()
        {

        }

        //CREATE
        public bool CreatePromotion(PromotionCreate model)
        {
            var entity = new Promotion()
            {
                PromotionDescription = model.PromotionDescription,
                PromoTypeId = model.PromoTypeId,
                PromotionValue = model.PromotionValue
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Promotions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<PromotionListItem> GetPromotions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Promotions.Select(
                             e =>
                                  new PromotionListItem
                                  {
                                      PromotionId = e.PromotionId,
                                      PromotionDescription = e.PromotionDescription,
                                      PromoType = e.PromoType.Type
                                  }
                                  );

                return query.ToArray();
            }
        }

        //GET BY ID
        public PromotionDetail GetPromotionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Promotions.Single(e => e.PromotionId == id);
                return new PromotionDetail
                {
                    PromotionId = entity.PromotionId,
                    PromotionDescription = entity.PromotionDescription,
                    PromoTypeId = entity.PromoTypeId,
                    PromoType = entity.PromoType.Type,
                    PromotionValue = entity.PromotionValue
                    
                };
            }
        }

        //UPDATE
        public bool UpdatePromotion(PromotionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Promotions
                    .Single(e => e.PromotionId == model.PromotionId);

                entity.PromotionDescription = model.PromotionDescription;
                entity.PromoTypeId = model.PromoTypeId;
                entity.PromotionValue = model.PromotionValue;
                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeletePromotion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Promotions.Single(e => e.PromotionId == id);

                ctx.Promotions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
