using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        //public string PhotoPath { get; set; }

        public virtual ICollection<PhotoDetail> PhotoDetail { get; set; }
        public virtual ICollection<PostTagTechnical> Tags { get; set; }
    }
}
