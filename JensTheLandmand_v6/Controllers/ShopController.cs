using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JensTheLandmand_v6.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace JensTheLandmand_v6.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Shop
        [AllowAnonymous]
        [Audit]
        public async Task<ActionResult> Index()
        {
            var item = await db.Products.ToListAsync();
            var item2 = await db.File.ToListAsync();                      

            ProductViewModel view = new ProductViewModel();
            view.allProducts = item;
            view.AllFiles = item2;

            return View(view);
        }

        public FileContentResult LoadImage(string path)
        {
            byte[] imgArray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(imgArray, "image/jpg");
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public ActionResult CreateProduct()
        {
            return View(new Products());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> CreateProduct([Bind(Include = "ProductName, ProductDesc, ProductPrice")] Products product, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        product.Files = new List<File> { avatar };
                    }
                    db.Products.Add(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Products product = db.Products.Find(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> EditProduct(
            [Bind(Include = "ProductID, ProductName, ProductDesc, ProductPrice")] Products product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [Audit]
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductDetails view = new ProductDetails();

            var item3 = db.Products.First(x => x.ProductID == id);
            var item4 = db.File.First(x => x.ProductId == id);

            view.Product = item3;
            view.ImgPath = item4;
            
            return View(view);
        }
    }
}