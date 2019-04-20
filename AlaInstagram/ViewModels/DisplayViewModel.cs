using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlaInstagram.ViewModels
{
    public class DisplayViewModel
    {
        public string Title { get; set; }
        //public string PhotoPath { get; set; }
        public List<string> PhotoPath { get; set; }
        public List<string> Tags { get; set; }
    }
}
