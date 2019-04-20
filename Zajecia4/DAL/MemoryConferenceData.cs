using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia4.Models;

namespace Zajecia4.DAL
{
    public class MemoryConferenceData : IConferenceData
    {
        public static List<ConferenceUser> RegisteredUsers { get; private set; } =
              new List<ConferenceUser>();

        public IEnumerable<ConferenceUser> GetUsers()
        {
            return RegisteredUsers;
        }

        public void SaveUser(ConferenceUser conferenceUser)
        {
            RegisteredUsers.Add(conferenceUser);
        }
    }
}
