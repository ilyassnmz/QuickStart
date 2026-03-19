using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    // PDF'deki isimle birebir uyum için ayrı ViewComponent
    public class _DefaultFeatureServiceComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultFeatureServiceComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultServiceDto>>("api/Service");
            var top = (values ?? new List<ResultServiceDto>()).Take(3).ToList();
            return View(top);
        }
    }
}
