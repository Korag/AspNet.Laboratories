using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zajecia4.Models;

namespace Zajecia4.DAL
{
    public class JsonConferenceData : IConferenceData
    {
        private readonly IHostingEnvironment _environment;
        public string pathToDb;

        public JsonConferenceData(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
            pathToDb = _environment.WebRootPath + @"\MOCK_DATA.json";
        }

        public IEnumerable<ConferenceUser> GetUsers()
        {
            List<ConferenceUser> RegisteredUsers = new List<ConferenceUser>();

            using (StreamReader sr = new StreamReader(pathToDb))
            {
                var json = sr.ReadToEnd();
                try
                {
                   RegisteredUsers = JsonConvert.DeserializeObject<List<ConferenceUser>>(json);
                }
                catch (Exception e)
                {
                    var str = e.ToString();
                }
            }
            return RegisteredUsers;
        }

        public void SaveUser(ConferenceUser conferenceUser)
        {
            List<ConferenceUser> RegisteredUsers = new List<ConferenceUser>();

            using (StreamWriter sw = new StreamWriter(pathToDb))
            {
                var serialized = JsonConvert.SerializeObject(RegisteredUsers);
                sw.Write(serialized);
            }
        }
    }
}
