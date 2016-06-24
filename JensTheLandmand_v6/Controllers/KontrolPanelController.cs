using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using JensTheLandmand_v6.Models;

namespace JensTheLandmand_v6.Controllers
{
    [Authorize(Roles = "Security")]
    public class KontrolPanelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KontrolPanel
        [HttpGet]
        [Authorize(Roles = "Security")]
        public ActionResult Index()
        {
            return View();
        }

        //Den første piechart
        //Checker hvor ofte index-siderne bliver besøgt
        //Ide: Sæt den så unik IP kun kan klippe på den én gang
        public ActionResult PieChart()
        {
            ChartViewModel view = new ChartViewModel();

            var today = DateTime.Today;
            var date = today.Date;

            view.ForumList =
                db.AuditRecords.Where(
                    r => DbFunctions.TruncateTime(r.TimeAccessed) == date && r.URLAccessed == "/Forum");
            view.LinksList =
                db.AuditRecords.Where(
                    r => DbFunctions.TruncateTime(r.TimeAccessed) == date && r.URLAccessed == "/Links");
            view.ShopList =
                db.AuditRecords.Where(
                    r => DbFunctions.TruncateTime(r.TimeAccessed) == date && r.URLAccessed == "/Shop");

            return View(view);
        }

        //Piechart over besøgt details sider i butik
        public ActionResult DetailsPieChart()
        {
            ChartProductDetailsViewModel newList = new ChartProductDetailsViewModel()
            {
                DetailsList = db.AuditRecords.Where(r => r.URLAccessed.Contains("/Shop/Details/"))
            };

            List<int> intList = new List<int>();

            foreach (var audit in newList.DetailsList)
            {
               //stringList.Add(audit.URLAccessed);
                var number = audit.URLAccessed[audit.URLAccessed.Length - 1];
                int x = (int) char.GetNumericValue(number);
                intList.Add(x);
            }

            List<ChartProducts> chartList = new List<ChartProducts>();
            foreach (var i in intList)
            {
                if (chartList.Any(x => x.id == i) )
                {
                    chartList.First(x => x.id == i).counts++;
                }
                else
                {
                    ChartProducts item = new ChartProducts();
                    item.name = db.Products.First(x => x.ProductID == i).ProductName;
                    item.id = i;
                    item.counts = 1;
                    chartList.Add(item);
                }
            }
            newList.ChartSortedList = chartList;
            return View(newList);
        }

        //Ikke færdig. Listen er taget fra db, men mangler at fjerne dubs
        public ActionResult TotalUnikVisitsChart()
        {
            UnikVisitsViewModel view = new UnikVisitsViewModel();
            var rawIpList = db.AuditRecords.Where(x => x.IPAddress != null);
            List<string> unikIpList = new List<string>();

            foreach (var item in rawIpList)
            {
                if (!unikIpList.Contains(item.IPAddress))
                {
                    unikIpList.Add(item.IPAddress);
                }
                else
                {
                    // \[T]/
                }
            }
            view.IPList = unikIpList;
            return View(view);
        }

        [AllowAnonymous]
        public async Task<ActionResult> DisplayIpActivity()
        {
            var today = DateTime.Today;
            var date = today.Date;

            return View(await db.AuditRecords.Where(x => DbFunctions.TruncateTime(x.TimeAccessed) == date).OrderBy(r => r.IPAddress).ToListAsync());
        }
    }
}