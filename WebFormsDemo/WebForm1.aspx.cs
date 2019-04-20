using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebFormsDemo.Model;

namespace WebFormsDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnGetRss_Click(sender, e);
        }

        // alt + strzałka

        protected void btnGetRss_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                url = "https://news.google.com/rss?hl=pl&gl=PL&ceid=PL:pl";
            }

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

            Repeater1.DataSource = items;
            Repeater1.DataBind();
        }
    }
}