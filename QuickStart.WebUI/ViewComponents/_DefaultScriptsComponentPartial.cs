using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
