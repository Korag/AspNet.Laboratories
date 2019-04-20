using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.Models
{
    public class Tag
    {
        //public int Id { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Bez tabeli technicznej
        public virtual Post Post { get; set; }
        // Z wykorzystaniem tabeli technicznej
        public virtual ICollection<Post> Posts { get; set; }
    }
}
