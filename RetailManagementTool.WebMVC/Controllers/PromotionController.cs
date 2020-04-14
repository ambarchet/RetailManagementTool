using RetailManagementTool.Data;
using RetailManagementTool.Models.Promotion;
using RetailManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class PromotionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Promotion
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var service = new PromotionService();
            var model = service.GetPromotions();
            return View(model);
        }

        //CREATE:GET
        [Authorize(Roles = "Admin")]

        public ActionResult Create()
        {
            var PromotionTypesList = new List<SelectListItem>();
            var PromotionTypeQuery = from p in _db.PromotionTypes select p;
            foreach (var p in PromotionTypeQuery)
            {
                PromotionTypesList.Add(new SelectListItem { Value = p.PromotionTypeId.ToString(), Text = p.Type });
            }
            ViewBag.PromotionTypes = PromotionTypesList;


            return View();
        }
        //CREATE:POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PromotionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new PromotionService();
            service.CreatePromotion(model);
            return RedirectToAction("Index");
        }

        //GET BY ID
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int id)
        {
            var service = new PromotionService();
            var model = service.GetPromotionById(id);

            return View(model);
        }

        //UPDATE: GET
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var PromotionTypesList = new List<SelectListItem>();
            var PromotionTypeQuery = from p in _db.PromotionTypes select p;
            foreach (var p in PromotionTypeQuery)
            {
                PromotionTypesList.Add(new SelectListItem { Value = p.PromotionTypeId.ToString(), Text = p.Type });
            }
            ViewBag.PromotionTypes = PromotionTypesList;

            var service = new PromotionService();
            var detail = service.GetPromotionById(id);
            var model =
                new PromotionEdit
                {
                    PromotionId = detail.PromotionId,
                    PromotionDescription = detail.PromotionDescription,
                    PromoTypeId = detail.PromoTypeId,
                    PromotionValue = detail.PromotionValue
                };
            return View(model);
        }
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PromotionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PromotionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new PromotionService();

            if (service.UpdatePromotion(model))
            {
                TempData["SaveResult"] = "Your promotion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your promotion could not be updated.");
            return View(model);
        }

        //DELETE
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new PromotionService();
            var model = service.GetPromotionById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new PromotionService();

            string deleteResponse = service.DeletePromotion(id);

            switch (deleteResponse)
            {
                case "This Promotion is used by a Product":
                    return View("DeleteErrorP");

                case "This Promotion is used by a Department":
                    return View("DeleteErrorD");
                default:
                    TempData["SaveResult"] = "Your promotion was deleted";

                    return RedirectToAction("Index");
            }
        }

        //DeleteError Product-Related
        public ActionResult DeleteErrorP()
        {
            return View();
        }

        //DeleteError Department-Related
        public ActionResult DeleteErrorD()
        {
            return View();
        }


    }
}