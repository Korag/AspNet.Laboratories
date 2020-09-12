using System;
using System.ComponentModel.DataAnnotations;

namespace AlaInstagram.Models
{
    public class PhotoDetail
    {
        [Key]
        public Guid PhotoId { get; set; }
        public string Path { get; set; }
        public Guid PostId { get; set; }
    }
}
