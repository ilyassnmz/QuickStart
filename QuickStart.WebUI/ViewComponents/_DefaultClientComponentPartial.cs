using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultClientComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultClientComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultClientDto>>("api/Client");
            var active = (values ?? new List<ResultClientDto>())
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .ToList();
            return View(active);
        }
    }
}
