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
            var service = new DepartmentService();
            var detail = service.GetDepartmentById(id);
            var model =
                new DepartmentEdit
                {
                    DepartmentId = detail.DepartmentId,
                    DepartmentNumber = detail.DepartmentNumber,
                    DepartmentName = detail.DepartmentName
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