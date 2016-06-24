using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JensTheLandmand_v6.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JensTheLandmand_v6
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            //hvis projektet bliver kørt lokalt kan der ske en fejl her.
            //Den første gang programmet kører, opretter den en admin bruger
            //Næste gang programmet kører vil den lave en fejl
            //Kommentere denne del ud, for at undgå den
            var context = new ApplicationDbContext();
            if (!context.Users.Any(user => user.UserName == "admin"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var applicationUser = new ApplicationUser() { UserName = "admin" };
                userManager.Create(applicationUser, "123456");
                //asdn6g7

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("Security"));

                userManager.AddToRole(applicationUser.Id, "Security");
            }
            //Hertil

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
