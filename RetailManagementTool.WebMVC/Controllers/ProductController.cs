using RetailManagementTool.Data;
using RetailManagementTool.Models.Product;
using RetailManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Department
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index(string SKU)
        {
            var service = new ProductService();

            if (SKU == null)
            {
            var model = service.GetProducts();
            return View(model);
            }

            var query = service.GetProductBySKU(SKU);
                return View(query);
        }

        //CREATE:GET
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var DepartmentsList = new List<SelectListItem>();
            var DepartmentQuery = from d in _db.Departments select d;
            foreach (var d in DepartmentQuery)
            {
                DepartmentsList.Add(new SelectListItem { Value = d.DepartmentId.ToString(), Text = d.DepartmentNumber });
            }
            ViewBag.Departments = DepartmentsList;

            var SizesList = new List<SelectListItem>();
            var SizeQuery = from s in _db.Sizes select s;
            foreach (var s in SizeQuery)
            {
                SizesList.Add(new SelectListItem { Value = s.SizeId.ToString(), Text = s.SizeName });
            }
            ViewBag.Sizes = SizesList;

            var PromotionsList = new List<SelectListItem>();
            var PromotionQuery = from p in _db.Promotions select p;
            foreach (var p in PromotionQuery)
            {
                PromotionsList.Add(new SelectListItem { Value = p.PromotionId.ToString(), Text = p.PromotionDescription });
            }
            ViewBag.Promotions = PromotionsList;

            var ZonesList = new List<SelectListItem>();
            var ZoneQuery = from z in _db.Zones select z;
            foreach (var z in ZoneQuery)
            {
                ZonesList.Add(new SelectListItem { Value = z.ZoneId.ToString(), Text = z.ZoneName });
            }
            ViewBag.Zones = ZonesList;

            return View();
        }
        //CREATE:POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            var service = new ProductService();
            service.CreateProduct(model);
            return RedirectToAction("Index");
        }

        //GET BY ID
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int id)
        {
            var service = new ProductService();
            var model = service.GetProductById(id);

            return View(model);
        }

        //GET PRODUCTS BY DEPARTMENT ID
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult ListByDepartmentNumber(int id)
        {
            var service = new ProductService();
            var model = service.GetProductsByDepartment(id);
            return View(model);
        }

        //UPDATE: GET
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var DepartmentsList = new List<SelectListItem>();
            var DepartmentQuery = from d in _db.Departments select d;
            foreach (var d in DepartmentQuery)
            {
                DepartmentsList.Add(new SelectListItem { Value = d.DepartmentId.ToString(), Text = d.DepartmentNumber });
            }
            ViewBag.Departments = DepartmentsList;

            var PromotionsList = new List<SelectListItem>();
            var PromotionQuery = from p in _db.Promotions select p;
            foreach (var p in PromotionQuery)
            {
                PromotionsList.Add(new SelectListItem { Value = p.PromotionId.ToString(), Text = p.PromotionDescription });
            }
            ViewBag.Promotions = PromotionsList;

            var SizesList = new List<SelectListItem>();
            var SizeQuery = from s in _db.Sizes select s;
            foreach (var s in SizeQuery)
            {
                SizesList.Add(new SelectListItem { Value = s.SizeId.ToString(), Text = s.SizeName });
            }
            ViewBag.Sizes = SizesList;

            var ZonesList = new List<SelectListItem>();
            var ZoneQuery = from z in _db.Zones select z;
            foreach (var z in ZoneQuery)
            {
                ZonesList.Add(new SelectListItem { Value = z.ZoneId.ToString(), Text = z.ZoneName });
            }
            ViewBag.Zones = ZonesList;

            var service = new ProductService();
            var detail = service.GetProductForEdit(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    ProductDepartmentId = detail.DepartmentId,
                    Style = detail.Style,
                    SKU = detail.SKU,
                    ProductName = detail.ProductName,
                    Color = detail.Color,
                    ProductSizeId = detail.SizeId,
                    TicketPrice = detail.TicketPrice,
                    ProductPromotionId = detail.PromotionId,
                    ProductZoneId = detail.ZoneId
                };
            return View(model);
        }
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new ProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        //DELETE
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ProductService();
            var model = service.GetProductById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your product was deleted";

            return RedirectToAction("Index");
        }

        //DeleteError
        public ActionResult DeleteError()
        {
            return View();
        }

    }
}