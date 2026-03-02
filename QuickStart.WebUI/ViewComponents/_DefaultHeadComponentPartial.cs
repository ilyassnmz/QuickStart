using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
