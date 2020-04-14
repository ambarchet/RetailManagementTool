using RetailManagementTool.Models.PromotionType;
using RetailManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class PromotionTypeController : Controller
    {


        // GET: PromotionType
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var service = new PromotionTypeService();
            var model = service.GetPromotionTypes();
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
        public ActionResult Create(PromotionTypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new PromotionTypeService();

            service.CreatePromotionType(model);

            return RedirectToAction("Index");
        }

        //GET BY ID
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int id)
        {
            var service = new PromotionTypeService();
            var model = service.GetPromotionTypeById(id);

            return View(model);
        }

        //UPDATE: GET
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = new PromotionTypeService();
            var detail = service.GetPromotionTypeById(id);
            var model =
                new PromotionTypeEdit
                {
                    PromotionTypeId = detail.PromotionTypeId,
                    Type = detail.Type,
                };
            return View(model);
        }
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PromotionTypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PromotionTypeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new PromotionTypeService();

            if (service.UpdatePromotionType(model))
            {
                TempData["SaveResult"] = "Your promotion type was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your promotion type could not be updated.");
            return View(model);
        }

        //DELETE
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new PromotionTypeService();
            var model = service.GetPromotionTypeById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new PromotionTypeService();
            string deleteResponse = service.DeletePromotionType(id);

            if (deleteResponse == "Promotion Type successfullly deleted")
            {
            TempData["SaveResult"] = "Your promotion type was deleted";
            return RedirectToAction("Index");

            }
            return View("DeleteError");
        }

        //DeleteError
        public ActionResult DeleteError()
        {
            return View();
        }
    }
}
