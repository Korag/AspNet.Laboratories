using AlaInstagram.Models;
using System.Collections.Generic;
using System.Linq;

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

        public void AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public IEnumerable<PhotoDetail> GetPhotoDetail()
        {
            return _context.PhotoDetails.ToList();
        }

        public IEnumerable<PostTagTechnical> GetPostTag()
        {
            return _context.PostTagTechnical.ToList();
        }

        public IEnumerable<Tag> GetTags(string Tags)
        {
            List<Tag> tags = new List<Tag>();

            foreach (var singleTag in Tags.Split(','))
            {
                var tagExist = _context.Tags.Where(x => x.Name == singleTag).FirstOrDefault();

                if (tagExist == null)
                {
                    tags.Add(new Tag { Name = singleTag });
                }
                else
                {
                    tags.Add(tagExist);
                }
            }
            return tags;
        }
    }
}
