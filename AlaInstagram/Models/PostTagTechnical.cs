﻿using System;
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
        // Tagi
        //public Guid TagId { get; set; }
        public string TagName { get; set; }


        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
