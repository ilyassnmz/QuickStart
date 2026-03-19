using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultGalleryComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultGalleryComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultGalleryDto>>("api/Gallery");
            var active = (values ?? new List<ResultGalleryDto>())
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .ToList();
            return View(active);
        }
    }
}
