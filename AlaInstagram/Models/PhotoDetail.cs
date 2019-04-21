using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
