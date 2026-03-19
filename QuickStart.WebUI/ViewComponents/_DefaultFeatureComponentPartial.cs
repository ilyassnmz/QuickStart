using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;
        public _DefaultFeatureComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultFeatureDto>>("api/Feature");
            return View(values ?? new List<ResultFeatureDto>());
        }
    }
}