using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Zajecia4.DAL;

namespace Components.Demo.Components
{
    public class RegisteredListViewComponent : ViewComponent
    {
        private readonly IHostingEnvironment _environment;
        private IConferenceData _conferenceData;
        public string pathToDb;

        public RegisteredListViewComponent(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
            pathToDb = _environment.WebRootPath + @"\MOCK_DATA.json";
            _conferenceData = new JsonConferenceData(_environment);
        }

        public IViewComponentResult Invoke()
        {
            var Users = _conferenceData.GetUsers();
            return View(Users);
        }
    }
}
