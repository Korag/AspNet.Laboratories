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

        IEnumerable<PostTagTechnical> GetPostsTags();
        void AddPostTag(PostTagTechnical postTag);

        IEnumerable<Tag> GetTags();
        void AddTag(Tag tag);
    }
}
