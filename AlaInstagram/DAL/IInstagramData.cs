using AlaInstagram.Models;
using System.Collections.Generic;

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
