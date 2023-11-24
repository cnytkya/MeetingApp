using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
