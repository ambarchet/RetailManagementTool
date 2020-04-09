using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetailManagementTool.Data;
using RetailManagementTool.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Services
{
    public class RoleService
    {
        ApplicationDbContext context = new ApplicationDbContext();


        public RoleService()
        {

        }

        //CREATE
        public bool CreateRole(RoleCreate model)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };

            

            roleManager.Create(identityRole);

            return context.SaveChanges() == 1;
        }

    }
}
