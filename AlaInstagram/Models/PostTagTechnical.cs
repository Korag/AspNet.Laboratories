using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.Models
{
    // Tabela techniczna
    public class PostTagTechnical
    {
        // Posty
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        // Tagi
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
