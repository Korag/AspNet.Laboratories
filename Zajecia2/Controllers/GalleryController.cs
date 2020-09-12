using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Zajecia2.Models;

namespace Zajecia2.Controllers
{
    public class GalleryController : Controller
    {
        public object JsonCovert { get; private set; }

        // GET: Gallery
        public ActionResult Index()
        {
            //1. pobrać zdjęcia
            //2. wysłać do widoku
            //3. zaimplementować widok

            WebClient wc = new WebClient();
            var url = "https://api.unsplash.com/photos/?client_id=3b0a0209eb25768ee4fa0ee3d8addf66c5aa321a0b4b7d5b312ff39574c3298b&page=2";
            var json = wc.DownloadString(url);

            var apiResponse = JsonConvert.DeserializeObject<List<ApiResponse>>(json);

            var images = apiResponse.Select(n => new ImageModel
            {
                ThumbUrl = n.ImageUrls.Thumb,
                RegularUrl = n.ImageUrls.Regular,

            }).ToList();

            return View(images);
        }
    }
}