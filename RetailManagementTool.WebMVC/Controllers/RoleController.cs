using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetailManagementTool.Services;
using RetailManagementTool.Data;
using RetailManagementTool.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace RetailManagementTool.WebMVC.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();


        public bool IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // GET: Roles
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            if (User.Identity.IsAuthenticated)
            {

                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);

        }

        //CREATE:GET
        public ActionResult Create()
        {
            return View();
        }
        //CREATE:POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new Services.RoleService();

            service.CreateRole(model);

            return RedirectToAction("Index");
        }
    }
}