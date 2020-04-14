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
                PromoValue = model.PromotionValue
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
        public PromotionDetail GetPromotionById(int? id)
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
                    PromotionValue = entity.PromoValue

                };
            }
        }

        //GET BY PROMOTYPEID
        public IEnumerable<PromotionDetail> GetPromotionByPromoType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Promotions
                    .Where(e => e.PromoTypeId == id)
                    .Select(e => new PromotionDetail
                    {
                        PromotionId = e.PromotionId,
                        PromotionDescription = e.PromotionDescription,
                        PromoTypeId = e.PromoTypeId,
                        PromoType = e.PromoType.Type,
                        PromotionValue = e.PromoValue
                    }
                                  );
                return query.ToList();
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
                entity.PromoValue = model.PromotionValue;
                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public string DeletePromotion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Promotions.Single(e => e.PromotionId == id);

                var service = new ProductService();
                var query = service.GetProductByPromotion(id);
                if (query.ToList().Count() >= 1)
                {
                    return "This Promotion is used by a Product";
                }
                try
                {
                    var dService = new DepartmentService();
                    var list = dService.GetDepartmentsByPromotion(id);
                    if (list.ToList().Count() == 0)
                    {
                        try
                        {
                            ctx.Promotions.Remove(entity);
                            ctx.SaveChanges();
                            return "Promotion successfully deleted";
                        }
                        catch (Exception s)
                        {
                            return s.Message;
                        }
                    }
                }
                catch (Exception n)
                {
                return n.Message;
                }
            }
                    return "This Promotion is used by a Department";
        }

    }
}
