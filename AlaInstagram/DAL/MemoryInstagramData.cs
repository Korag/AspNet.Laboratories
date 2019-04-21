using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlaInstagram.Models;

namespace AlaInstagram.DAL
{
    public class MemoryInstagramData : IInstagramData
    {
        public static List<Post> PublishedPosts { get; private set; } =
              new List<Post>();
        public static List<PostTagTechnical> PostsWithTags { get; private set; } =
              new List<PostTagTechnical>();
        public static List<Tag> Tagss { get; private set; } =
           new List<Tag>();

        public void AddPost(Post post)
        {
            PublishedPosts.Add(post);
        }

        public IEnumerable<Post> GetPosts()
        {
            return PublishedPosts; 
        }

        public void AddTag(Tag tag)
        {
            Tagss.Add(tag);
        }

        public IEnumerable<Tag> GetTags(string Tags)
        {
            return Tagss;
        }

        public IEnumerable<PhotoDetail> GetPhotoDetail()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostTagTechnical> GetPostTag()
        {
            throw new NotImplementedException();
        }
    }
}
