using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Notification;

namespace QuickStart.WebUI.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _AdminLayoutNavbarComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultNotificaitonWithNotificationTypeDto>>(
                "api/Notification/GetNotificationListwithNotificationType");
            return View(values ?? new List<ResultNotificaitonWithNotificationTypeDto>());
        }
    }
}
