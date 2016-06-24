using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JensTheLandmand_v6.Models;

namespace JensTheLandmand_v6.Controllers
{
    public class AuditController : Controller
    {
        // GET: Audit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAuditRecords()
        {
            var audits = new ApplicationDbContext().AuditRecords;
            return View(audits);
        }
    }

    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;

            //Generate an audit
            Audit audit = new Audit()
            {
                AuditID = Guid.NewGuid(),
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                URLAccessed = request.RawUrl,
                TimeAccessed = DateTime.UtcNow,
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
            };

            //Stores the Audit in the Database
            ApplicationDbContext db = new ApplicationDbContext();
            db.AuditRecords.Add(audit);
            db.SaveChanges();         

            base.OnActionExecuting(filterContext);
        }
    }
}