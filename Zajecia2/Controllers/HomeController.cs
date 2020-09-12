using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using Zajecia2.Models;

namespace Zajecia2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult RssDisplay()
        {
            //1. model
            //2. akcje
            //3. widok akcji

            var url = "https://news.google.com/rss?hl=pl&gl=PL&ceid=PL:pl";
     
            XElement rss = XElement.Load(url);

            //var query = from item in rss.Descendants("item")
            //            select new
            //            {
            //                Title = item.Element("title").Value,
            //                PubDate = item.Element("pubDate").Value,
            //                Description = item.Element("description").Value,
            //            };

            var query = rss.Descendants("item").Select(item => new RssItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                Description = item.Element("description").Value,
            });

            var items = query.ToList();

            return View(items);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}