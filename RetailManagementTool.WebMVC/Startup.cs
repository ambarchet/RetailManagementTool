using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RetailManagementTool.Data;
using System.Data.Entity.Migrations;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(RetailManagementTool.WebMVC.Startup))]
namespace RetailManagementTool.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
            Seed();
        }


        //Create default User roles and Admin user for login  
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                //Create Admin role    
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Create an Admin super user who will maintain the website                   
                var user = new ApplicationUser();
                user.UserName = "Master";
                user.Email = "master@gmail.com";
                string userPWD = "Master1!";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Creating Employee role     
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
        private void Seed()
        {

            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            context.Sizes.AddOrUpdate
               (
               x => x.SizeName,
               new Size()
               {
                   SizeName = "XS"
               },
               new Size()
               {
                   SizeName = "S"
               },
               new Size()
               {
                   SizeName = "M"
               },
               new Size()
               {
                   SizeName = "L"
               },
               new Size()
               {
                   SizeName = "XL"
               },
               new Size()
               {
                   SizeName = "W30xL32"
               },
               new Size()
               {
                   SizeName = "W32xL32"
               },
               new Size()
               {
                   SizeName = "00R"
               },
               new Size()
               {
                   SizeName = "02L"
               }
               );
            context.SaveChanges();

            context.Zones.AddOrUpdate
              (
              x => x.ZoneName,
              new Zone()
              {
                  ZoneName = "M Hot Zone"
              },
              new Zone()
              {
                  ZoneName = "M Zone 1"
              },
              new Zone()
              {
                  ZoneName = "M Zone 2"
              },
              new Zone()
              {
                  ZoneName = "M Clearance"
              },
              new Zone()
              {
                  ZoneName = "W Hot Zone"
              },
              new Zone()
              {
                  ZoneName = "W Zone 1"
              },
              new Zone()
              {
                  ZoneName = "W Zone 2"
              },
              new Zone()
              {
                  ZoneName = "W Clearance"
              }
              );
            context.SaveChanges();

            context.PromotionTypes.AddOrUpdate
             (
             x => x.Type,
             new PromotionType()
             {
                 Type = "Percent Off"
             },
             new PromotionType()
             {
                 Type = "New Dollar Amount"
                 
             },
             new PromotionType()
             {
                 Type = "BOGO Percent"
             },
            new PromotionType()
            {
                Type = "BOGO Dollar Amount"

            },
             new PromotionType()
             {
                 Type = "No Promo"
             }
             );

            context.SaveChanges();
        }
    }
}
