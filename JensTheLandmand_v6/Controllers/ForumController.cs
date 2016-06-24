using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using JensTheLandmand_v6.Models;
using Microsoft.AspNet.Identity;

namespace JensTheLandmand_v6.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forum   
        [Audit]
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Her kan der diskuteres eller stilles spørgsmål omkring landbrug";

            return View(await db.Topics.ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateTopic()
        {
            return View();;
        }

        [Audit]
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTopic([Bind(Include = "TopicTitle, TopicNote")] Topics topic)
        {
            if (ModelState.IsValid)
            {
                topic.Creator = User.Identity.GetUserName();

                db.Topics.Add(topic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [Audit]
        [HttpGet]
        public ActionResult Comments(int id)
        {
            ViewTopicAndCommentsViewModel view = new ViewTopicAndCommentsViewModel();
            view.topic = db.Topics.FirstOrDefault(x => x.TopicID == id);
            //view.topic = db.Topics.Where(x => x.TopicID == id);

            string currentUserId = User.Identity.GetUserId();
            view.user = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            view.comments = db.Comments.Where(x => x.C_TopicId == id);

            return View(view);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateComment(int id)
        {
            return View();
        }

        [Audit]
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateComment(int id, [Bind(Include = "CommentID, Comment")] Comments replyComment)
        {
            if (ModelState.IsValid)
            {
                replyComment.Creator = User.Identity.GetUserName();
                replyComment.C_TopicId = id;

                db.Comments.Add(replyComment);
                await db.SaveChangesAsync();
                return RedirectToAction("Comments", new { id = id});
            }
            return View(replyComment);
        }
        //PRAISE THE SUN \[T]/

        [HttpGet]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> DeleteTopic(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topic = await db.Topics.FindAsync(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        [HttpPost, ActionName("DeleteTopic")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Topics topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> EditTopic(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topic = await db.Topics.FindAsync(id);

            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Security")]
        public async Task<ActionResult> EditTopic(
            [Bind(Include = "TopicID, T_AspNetUserId, TopicTitle, TopicNote, Creator")] Topics topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(topic);
        }
    }
}