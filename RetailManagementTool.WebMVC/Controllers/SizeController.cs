using RetailManagementTool.Models.Size;
using RetailManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class SizeController : Controller
    {
        // GET: Size
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var service = new SizeService();
            var model = service.GetSizes();
            return View(model);
        }

        //CREATE:GET
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        //CREATE:POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SizeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SizeService();

            service.CreateSize(model);

            return RedirectToAction("Index");
        }

        //GET BY ID
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int id)
        {
            var service = new SizeService();
            var model = service.GetSizeById(id);

            return View(model);
        }

        //UPDATE: GET
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = new SizeService();
            var detail = service.GetSizeById(id);
            var model =
                new SizeEdit
                {
                    SizeId = detail.SizeId,
                    SizeName = detail.SizeName,
                };
            return View(model);
        }
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SizeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SizeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new SizeService();

            if (service.UpdateSize(model))
            {
                TempData["SaveResult"] = "Your size was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your size could not be updated.");
            return View(model);
        }

        //DELETE
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new SizeService();
            var model = service.GetSizeById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new SizeService();

            service.DeleteSize(id);

            TempData["SaveResult"] = "Your size was deleted";

            return RedirectToAction("Index");
        }
    }
}