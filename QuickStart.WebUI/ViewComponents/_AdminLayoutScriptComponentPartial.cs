using Microsoft.AspNetCore.Mvc;
namespace QuickStart.WebUI.ViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
