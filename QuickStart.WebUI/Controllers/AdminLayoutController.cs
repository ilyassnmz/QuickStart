using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
