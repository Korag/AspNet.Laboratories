using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zajecia4.Models
{
    public enum ConferenceType
    {
        Lecture,
        Workshop,
        Discussion
    }

    public class ConferenceUser
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ConferenceType? ConferenceType { get; set; }
        //public IFormFile Avatar { get; set; }
        public string Avatar{ get; set; }
        //public byte[] AvatarImg { get; set; }
    }
}
