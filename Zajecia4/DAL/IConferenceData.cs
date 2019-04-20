using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia4.Models;

namespace Zajecia4.DAL
{
    public interface IConferenceData
    {
        IEnumerable<ConferenceUser> GetUsers();
        void SaveUser(ConferenceUser conferenceUser);
    }
}
