using AlaInstagram.DAL;
using AlaInstagram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.DAL
{
    public class EFInstagramData : IInstagramData
    {
        private InstagramContext _context;

        public EFInstagramData()
        {
            _context = new InstagramContext();
            _context.Database.EnsureCreated();
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void AddPostTag(PostTagTechnical postTag)
        {
            _context.PostTag.Add(postTag);
            _context.SaveChanges();
        }

        public void AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public IEnumerable<PostTagTechnical> GetPostsTags()
        {
            return _context.PostTag.ToList();
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags.ToList();
        }
    }
}
