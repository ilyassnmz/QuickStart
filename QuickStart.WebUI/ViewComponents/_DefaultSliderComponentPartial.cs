using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;
        public _DefaultSliderComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultSliderDto>>("api/Slider");
            return View(values ?? new List<ResultSliderDto>());
        }
    }
}