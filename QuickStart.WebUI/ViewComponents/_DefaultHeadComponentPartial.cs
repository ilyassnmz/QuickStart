using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.ViewComponents
{
    [ViewComponent(Name = "_DefaultHeadComponentPartial")]
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}