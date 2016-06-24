using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JensTheLandmand_v6.Controllers
{
    public class HomeController : Controller
    {
        [Audit]
        public ActionResult Index()
        {
            return View("Index", "_FrontPageView");
        }
    }
}