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
        public static List<PostTagTechnical> PostTagTechnical{ get; private set; } =
              new List<PostTagTechnical>();

        public static List<PhotoDetail> PhotoDetails { get; private set; } =
              new List<PhotoDetail>();

        public static List<Tag> Tags { get; private set; } =
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
            Tags.Add(tag);
        }

        public IEnumerable<Tag> GetTags(string tags)
        {
            return Tags;
        }

        public IEnumerable<PhotoDetail> GetPhotoDetail()
        {
            return PhotoDetails;
        }

        public IEnumerable<PostTagTechnical> GetPostTag()
        {
            return PostTagTechnical;
        }
    }
}
