using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
