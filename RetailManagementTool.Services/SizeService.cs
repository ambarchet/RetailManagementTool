using RetailManagementTool.Data;
using RetailManagementTool.Models.Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class SizeService
    {
        public SizeService()
        {

        }

        //CREATE
        public bool CreateSize(SizeCreate model)
        {
            var entity = new Size()
            {
                SizeName = model.SizeName,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sizes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<SizeListItem> GetSizes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Sizes.Select(
                             e =>
                                  new SizeListItem
                                  {
                                      SizeId = e.SizeId,
                                      SizeName = e.SizeName,
                                  }
                                  );

                return query.ToArray();
            }
        }

        //GET BY ID
        public SizeDetail GetSizeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sizes.Single(e => e.SizeId == id);
                return new SizeDetail
                {
                    SizeId = entity.SizeId,
                    SizeName = entity.SizeName,
                };
            }
        }

        //UPDATE
        public bool UpdateSize(SizeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sizes
                    .Single(e => e.SizeId == model.SizeId);

                entity.SizeName = model.SizeName;
                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteSize(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sizes.Single(e => e.SizeId == id);

                ctx.Sizes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
