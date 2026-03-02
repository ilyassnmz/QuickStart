using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
