﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlaInstagram.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Tags")]
        public string CommaSeparatedTags { get; set; }
        //[Required]
        //public IFormFile Image { get; set; }

        // Multiple images
        [Required]
        public ICollection<IFormFile> Image { get; set; }
    }
}
