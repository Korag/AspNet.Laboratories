using System.Collections.Generic;

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
