using RetailManagementTool.Models.Zone;
using RetailManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class ZoneController : Controller
    {
        // GET: Zone
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            var service = new ZoneService();
            var model = service.GetZones();
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
        public ActionResult Create(ZoneCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ZoneService();

            service.CreateZone(model);

            return RedirectToAction("Index");
        }

        //GET BY ID
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int id)
        {
            var service = new ZoneService();
            var model = service.GetZoneById(id);

            return View(model);
        }

        //UPDATE: GET
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = new ZoneService();
            var detail = service.GetZoneById(id);
            var model =
                new ZoneEdit
                {
                    ZoneId = detail.ZoneId,
                    ZoneName = detail.ZoneName,
                };
            return View(model);
        }
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ZoneEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ZoneId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new ZoneService();

            if (service.UpdateZone(model))
            {
                TempData["SaveResult"] = "Your zone was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your zone could not be updated.");
            return View(model);
        }

        //DELETE
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ZoneService();
            var model = service.GetZoneById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ZoneService();

            string deleteResponse = service.DeleteZone(id);

            if (deleteResponse == "Zone successfully deleted")
            {
            TempData["SaveResult"] = "Your zone was deleted";
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