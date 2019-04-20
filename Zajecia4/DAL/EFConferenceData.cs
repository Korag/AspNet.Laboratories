using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia4.Models;

namespace Zajecia4.DAL
{
    public class EFConferenceData : IConferenceData
    {
        private ConferenceContext _context;

        public EFConferenceData()
        {
            _context = new ConferenceContext();
            _context.Database.EnsureCreated();
        }

        public IEnumerable<ConferenceUser> GetUsers()
        {
            return _context.ConferenceUsers.ToList(); 
        }

        public void SaveUser(ConferenceUser conferenceUser)
        {
            _context.ConferenceUsers.Add(conferenceUser);
            _context.SaveChanges();
        }
    }
}
