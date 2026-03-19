using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultFooterComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultContactInfoDto>>("api/ContactInfo");
            return View(values?.FirstOrDefault() ?? new ResultContactInfoDto());
        }
    }
}