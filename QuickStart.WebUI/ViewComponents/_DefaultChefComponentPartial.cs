using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultChefComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultChefComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultChefDto>>("api/Chef");
            var active = (values ?? new List<ResultChefDto>())
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .ToList();
            return View(active);
        }
    }
}
