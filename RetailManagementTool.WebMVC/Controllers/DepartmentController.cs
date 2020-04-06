using RetailManagementTool.Data;
using RetailManagementTool.Models.Department;
using RetailManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Department
        public ActionResult Index()
        {
            var service = new DepartmentService();
            var model = service.GetDepartments();
            return View(model);
        }

        //CREATE:GET
        public ActionResult Create()
        {
            var PromotionsList = new List<SelectListItem>();
            var PromoQuery = from p in _db.Promotions select p;
            foreach (var p in PromoQuery)
            {
                PromotionsList.Add(new SelectListItem { Value = p.PromotionId.ToString(), Text = p.PromotionDescription });
            }
            ViewBag.Promotions = PromotionsList;

            // ViewBag.PromotionId = new SelectList(_db.Promotions, "PromotionId", "PromotionId");
            return View();
        }
        //CREATE:POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentCreate model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            var service = new DepartmentService();
            service.CreateDepartment(model);
            return RedirectToAction("Index");
        }

        //GET BY ID
        public ActionResult Details(int id)
        {
            var service = new DepartmentService();
            var model = service.GetDepartmentById(id);

            return View(model);
        }

        //UPDATE: GET
        public ActionResult Edit(int id)
        {
            var PromotionsList = new List<SelectListItem>();
            var PromoQuery = from p in _db.Promotions select p;
            foreach (var p in PromoQuery)
            {
                PromotionsList.Add(new SelectListItem { Value = p.PromotionId.ToString(), Text = p.PromotionDescription });
            }
            ViewBag.Promotions = PromotionsList;

            var service = new DepartmentService();
            var detail = service.GetDepartmentById(id);
            var model =
                new DepartmentEdit
                {
                    DepartmentId = detail.DepartmentId,
                    DepartmentNumber = detail.DepartmentNumber,
                    DepartmentName = detail.DepartmentName,
                    DepartmentPromotionId = detail.DepartmentPromotionId
                };
            return View(model);
        }
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DepartmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new DepartmentService();

            if (service.UpdateDepartment(model))
            {
                TempData["SaveResult"] = "Your department was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your department could not be updated.");
            return View(model);
            
        }

        //DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new DepartmentService();
            var model = service.GetDepartmentById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new DepartmentService();

            service.DeleteDepartment(id);

            TempData["SaveResult"] = "Your department was deleted";

            return RedirectToAction("Index");
        }

    }
}