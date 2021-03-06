﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlaInstagram.DAL;
using AlaInstagram.Models;
using AlaInstagram.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class PostController : Controller
    {
        private IInstagramData _instagramData;
        private IHostingEnvironment _environment;

        public PostController(IHostingEnvironment environment)
        {
            _environment = environment;
            _instagramData = new EFInstagramData();
            //_instagramData = new MemoryInstagramData();
        }

        // GET: Post
        public ActionResult Index(int page = 0)
        {
            var PublishedPosts = _instagramData.GetPosts();

            var DisplayViewModels = PublishedPosts.OrderByDescending(n => n.AddedTime).Select(n => new DisplayViewModel
            {
                Title = n.Title,
                PhotoPath = _instagramData.GetPhotoDetail().Where(x => n.Id == x.PostId).Select(x=> x.Path).ToList(),
                Tags = _instagramData.GetPostTag().Where(x=> n.Id == x.PostId).Select(x=> x.TagName).ToList(), 
            }).Skip((page - 1) * 10).Take(10);

            //var DisplayViewModels = PublishedPosts.Select(n => new DisplayViewModel
            //{
            //    Title = n.Title,
            //    PhotoPath = n.PhotoPath,
            //    Tags = n.Tags.Select(t => t.Name).ToList()
            //}).Reverse().Skip((page - 1) * 10).Take(10);

            double LastPageIndex = Math.Ceiling(PublishedPosts.Count() / 10.0) - 1;

            ViewBag.LastPageIndex = LastPageIndex;
            ViewBag.PageNumber = page;

            return View(DisplayViewModels);
        }

        // GET: Post/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel postViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var folderName = "Upload";

                    Post p = new Post
                    {
                        Id = Guid.NewGuid(),
                        Title = postViewModel.Title,
                        PhotoDetail = new List<PhotoDetail>(),
                        //PhotoPath = "/" + folderName + "/" + postViewModel.Image.FileName,
                        Tags = new List<PostTagTechnical>(),
                        AddedTime = DateTime.Now
                    };

                    foreach (var singleImage in postViewModel.Image)
                    {
                        var savePath = Path.Combine(_environment.WebRootPath, folderName, singleImage.FileName);

                        using (var photoFile = new FileStream(savePath, FileMode.Create))
                        {
                            singleImage.CopyTo(photoFile);

                            p.PhotoDetail.Add(new PhotoDetail { PhotoId = new Guid(), Path = "/" + folderName + "/" + singleImage.FileName });
                        }
                    }        

                    var tags = _instagramData.GetTags(postViewModel.CommaSeparatedTags);

                    foreach (var tag in tags)
                    {
                        p.Tags.Add(new PostTagTechnical
                        {
                            Post = p,
                            Tag = tag,
                        });
                    }

                    _instagramData.AddPost(p);

                    return RedirectToAction(nameof(Index));
                }

                return View(postViewModel);

            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}