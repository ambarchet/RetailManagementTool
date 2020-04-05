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
                                      DepartmentName = e.DepartmentName
                                  }
                                  );

                return query.ToArray();
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
                    //PromotionDescription = entity.DepartmentPromotion.PromotionDescription
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
                entity.DepartmentName = entity.DepartmentName;
                //  entity.DepartmentPromotion.PromotionDescription = model.PromotionDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteDepartment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Departments.Single(e => e.DepartmentId == id);

                ctx.Departments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
