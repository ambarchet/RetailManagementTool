using RetailManagementTool.Data;
using RetailManagementTool.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class DepartmentService
    {
        public DepartmentService()
        {

        }

        //CREATE
        public bool CreateDepartment(DepartmentCreate model)
        {
            var entity = new Department()
            {
                DepartmentNumber = model.DepartmentNumber,
                DepartmentName = model.DepartmentName,
                DepartmentPromotionId = model.DepartmentPromotionId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<DepartmentListItem> GetDepartments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Departments.Select(
                             e =>
                                  new DepartmentListItem
                                  {
                                      DepartmentId = e.DepartmentId,
                                      DepartmentNumber = e.DepartmentNumber,
                                      DepartmentName = e.DepartmentName,
                                      DepartmentPromoDescription = e.DepartmentPromotion.PromotionDescription
                                  }
                                  );

                query.ToList();
                List<DepartmentListItem> orderedByDepartmentNumber = query.OrderBy(e => e.DepartmentNumber).ToList();
                return orderedByDepartmentNumber;
            }
        }

        //GET BY PROMOTION
        public IEnumerable<DepartmentDetail> GetDepartmentsByPromotion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Departments
                    .Where(e => e.DepartmentPromotionId == id)
                    .Select(e => new DepartmentDetail
                    {
                        DepartmentId = e.DepartmentId,
                        DepartmentNumber = e.DepartmentNumber,
                        DepartmentName = e.DepartmentName,
                        DepartmentPromotionId = e.DepartmentPromotionId,
                        DepartmentPromotionName = e.DepartmentPromotion.PromotionDescription
                    }
                                  );

                return query.ToList();
            }
        }



        //GET BY ID
        public DepartmentDetail GetDepartmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Departments.Single(e => e.DepartmentId == id);
                return new DepartmentDetail
                {
                    DepartmentId = entity.DepartmentId,
                    DepartmentNumber = entity.DepartmentNumber,
                    DepartmentName = entity.DepartmentName,
                    DepartmentPromotionId = entity.DepartmentPromotionId,
                    DepartmentPromotionName = entity.DepartmentPromotion.PromotionDescription
                };
            }
        }

        //UPDATE
        public bool UpdateDepartment(DepartmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Departments
                    .Single(e => e.DepartmentId == model.DepartmentId);

                entity.DepartmentNumber = model.DepartmentNumber;
                entity.DepartmentName = model.DepartmentName;
                entity.DepartmentPromotionId = model.DepartmentPromotionId;


                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public string DeleteDepartment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Departments.Single(e => e.DepartmentId == id);

                var service = new ProductService();
                var query = service.GetProductEditDetailByDepartment(id);
                if (query.ToList().Count() == 0)
                {
                    try
                    {
                        ctx.Departments.Remove(entity);
                        ctx.SaveChanges();
                        return "Department successfully deleted";
                    }
                    catch (Exception s)
                    {
                        return s.Message;
                    }
                }
                return "Unable to delete this Department";
            }
        }
    }
}
