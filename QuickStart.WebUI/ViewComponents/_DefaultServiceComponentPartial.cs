using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultServiceComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;
        public _DefaultServiceComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultServiceDto>>("api/Service");
            return View(values ?? new List<ResultServiceDto>());
        }
    }
}