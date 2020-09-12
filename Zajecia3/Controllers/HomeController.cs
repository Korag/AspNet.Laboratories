using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Xml.Linq;
using Zajecia3.Models;

namespace Zajecia3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            List<RssItem> RandomizedItems = GenerateRssCollection();

            return View(RandomizedItems);
        }

        public List<RssItem> GenerateRssCollection()
        {
            var url = "https://www.tvn24.pl/internet-hi-tech-media,40.xml";
            var url2 = "https://www.tvn24.pl/internet-hi-tech-media,40.xml";
            var url3 = "https://nt.interia.pl/feed";

            var Items1 = GetRss(url);
            var Items2 = GetRss(url2);
            var Items3 = GetRss(url3);

            List<RssItem> AggregatedItems = new List<RssItem>();

            AggregatedItems.AddRange(Items1);
            AggregatedItems.AddRange(Items2);
            AggregatedItems.AddRange(Items3);

            Random rnd = new Random();
            List<RssItem> RandomizedItems = AggregatedItems.OrderBy(x => rnd.Next()).Take(4).ToList();
            foreach (var item in RandomizedItems)
            {
               var tmp = Regex.Replace(item.Description, @"<img\s[^>]*>(?:\s*?</img>)?", "", RegexOptions.IgnoreCase);
                item.Description = tmp;
            }

            return RandomizedItems;
        }

        public List<RssItem> GetRss(string url)
        {
            XElement rss = XElement.Load(url);
            var items = rss.Descendants("item").Select(item => new RssItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                Description = item.Element("description").Value,
                Links = item.Descendants("link").FirstOrDefault()?.Value,
            }).ToList();

            return items;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}