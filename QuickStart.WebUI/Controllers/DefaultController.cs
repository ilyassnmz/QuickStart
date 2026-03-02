using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
