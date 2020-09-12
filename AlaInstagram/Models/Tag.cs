using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlaInstagram.Models
{
    public class Tag
    {
        //public int Id { get; set; }
        //public Guid Id { get; set; }

        [Key]
        public string Name { get; set; }

        // Z wykorzystaniem tabeli technicznej
        public virtual ICollection<PostTagTechnical> Posts { get; set; }
    }
}
