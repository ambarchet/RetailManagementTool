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
        public ActionResult Index()
        {
            {
               /*
                            if (!String.IsNullOrEmpty(searching))
                            {
                                var query = _db.Products.Where(p => p.SKU.Contains(searching)).Select(q => new ProductListItem
                                {
                                    ProductId = q.ProductId,
                                    DepartmentNumber = q.ProductDepartment.DepartmentNumber,
                                    Style = q.Style,
                                    SKU = q.SKU,
                                    ProductName = q.ProductName,
                                    ZoneName = q.ProductZone.ZoneName,
                                    PromotionDescription = q.ProductPromotion.PromotionDescription
                                }
                                );
                                return View(query.ToList());


                                //   return View( _db.Products.Where(x => x.SKU.Contains(searching) || searching == null).ToList());
                            }
                      */      
            }

            var service = new ProductService();
            var model = service.GetProducts();
            return View(model);
        }

            /*
            */

        //CREATE:GET
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

            // ViewBag.PromotionId = new SelectList(_db.Promotions, "PromotionId", "PromotionId");
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
        public ActionResult Details(int id)
        {
            var service = new ProductService();
            var model = service.GetProductById(id);

            return View(model);
        }
        

        //GET PRODUCTS BY DEPARTMENT ID
        public ActionResult ListByDepartmentNumber(int id)
        {
            var service = new ProductService();
            var model = service.GetProductsByDepartment(id);
            return View(model);
        }














        //UPDATE: GET
        public ActionResult EditProductsByDepartment(int id)
        {
            // put a dropdown for promotions in here

            var PromotionsList = new List<SelectListItem>();
            var PromotionQuery = from p in _db.Promotions select p;
            foreach (var p in PromotionQuery)
            {
                PromotionsList.Add(new SelectListItem { Value = p.PromotionId.ToString(), Text = p.PromotionDescription });
            }
            ViewBag.Promotions = PromotionsList;

            //{
            //ProductList =  service.GetProductsByDepartment(id);
            //}
            var service = new ProductService();
            //new up a Model()
            var listitem = service.GetProductsByDepartment(id);
           // return View(listitem);

            var model =
                new ProductPromoEdit
                {
                    ProductsInDepartment = listitem,
                    PromotionId = id,
                };
            return View(model);


            // assign the value of the list of products to the list that our getProductsByDepartment returns
            // we'll set the value for the promotion in our view
        }
        //UpdateByDeptPost
        //take in our new model that should have the same list, and the promotion Id that we selected
        //pass that model into our service method that will change the promotion Id for each object in that list
        //return the view for the model after calling the update method
        //UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProductsByDepartment(int id, ProductPromoEdit model)
        {

            var service = new ProductService();
            var promoedit = service.UpdateListOfProducts(model);

            return View(promoedit);


            TempData["SaveResult"] = "Your product was updated.";
            return RedirectToAction("Index");

            /*
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
            */






        }


        //UPDATE: GET
        public ActionResult Edit(int id)
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

            var service = new ProductService();
            var detail = service.GetProductById(id);
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

    }
}