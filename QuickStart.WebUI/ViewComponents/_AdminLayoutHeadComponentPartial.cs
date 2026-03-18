using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

//ViewComponet->class _AdminLayoutHeadComponentPartial
//Shared-Components- oluşturudğum clasın ismine sahip dosya oluşturyorum _AdminLayoutHeadComponentPartial -Default view