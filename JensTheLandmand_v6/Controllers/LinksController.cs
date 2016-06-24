using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JensTheLandmand_v6.Models;

namespace JensTheLandmand_v6.Controllers
{
    public class LinksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Links
        [Audit]
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Her er mine foretrukne links";

            return View(await db.Links.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public ActionResult CreateLink()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> CreateLink([Bind(Include = "LinksID, LinkURL, LinkDesc")] Links link)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(link);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(link);
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> EditLink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links link = await db.Links.FindAsync(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> EditLink([Bind(Include = "LinksID, LinkURL, LinkDesc")] Links link)
        {
            if (ModelState.IsValid)
            {
                db.Entry(link).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(link);
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> DeleteLink(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links link = await db.Links.FindAsync(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        [HttpPost, ActionName("DeleteLink")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Links movie = await db.Links.FindAsync(id);
            db.Links.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}