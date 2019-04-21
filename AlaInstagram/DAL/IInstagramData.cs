using AlaInstagram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.DAL
{
    public interface IInstagramData
    {
        IEnumerable<Post> GetPosts();
        void AddPost(Post post);

        IEnumerable<Tag> GetTags(string Tags);
        void AddTag(Tag tag);

        IEnumerable<PhotoDetail> GetPhotoDetail();
        IEnumerable<PostTagTechnical> GetPostTag();
    }
}
