using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zajecia2.Models
{
    public class ApiResponse
    {
        // nested classes
        public class Urls
        {
            public string Regular { get; set; }
            public string Thumb { get; set; }
        }

        // jak sie nazywa plik + zmiana nazwy
        [JsonProperty(propertyName:"urls")]
        public Urls ImageUrls { get; set; }
    }
}
