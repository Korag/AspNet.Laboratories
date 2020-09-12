using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zajecia4.DAL;
using Zajecia4.Models;

namespace Zajecia4.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private IConferenceData _conferenceData;
        public string pathToDb;

        // Constructor
        public ConferenceController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
            pathToDb = _environment.WebRootPath + @"\MOCK_DATA.json";

            _conferenceData = new JsonConferenceData(_environment);
            //_conferenceData = new MemoryConferenceData();
            //_conferenceData = new EFConferenceData();
        }

        // GET: Conference/Index
        public ActionResult Index()
        {
            return View(_conferenceData.GetUsers());
        }

        // GET: Conference/Create
        public ActionResult Create()
        {
            var conferenceTypeStrings = new Dictionary<ConferenceType, string>
            {
                { ConferenceType.Lecture, "Wykład" },
                { ConferenceType.Workshop, "Warsztaty" },
                { ConferenceType.Discussion, "Dyskusja" },
            };

            var selectList = Enum.GetValues(typeof(ConferenceType))
                .Cast<ConferenceType>()
                .Select(n => new SelectListItem
                {
                    Value = n.ToString(), Text = conferenceTypeStrings[n]
                });

            ViewBag.ConferenceTypes = selectList;

            ViewBag.ListRegisteredUsers = _conferenceData.GetUsers();

            return View();
        }

        // POST: Conference/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConferenceUser conferenceUser)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, "avatarImages") + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        //PathDB = "avatarImages/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        conferenceUser.Avatar = newFileName;

                        // Avatar w tablicy byte
                        //conferenceUser.AvatarImg = System.IO.File.ReadAllBytes(fileName);
                    }
                }
            }

            try
            {
                // zapis do pamięci
                _conferenceData.SaveUser(conferenceUser);
                return RedirectToAction(nameof(Create));

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}