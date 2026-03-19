using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    [ViewComponent(Name = "_DefaultNavbarComponentPartial")]
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultNavbarComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            return View(values ?? new List<ResultNotificationTypeDto>());
        }
    }
}