using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;
        public _DefaultAboutComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultAboutDto>>("api/About");
            return View(values ?? new List<ResultAboutDto>());
        }
    }
}