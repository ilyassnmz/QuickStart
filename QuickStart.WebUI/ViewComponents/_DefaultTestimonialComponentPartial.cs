using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly Services.ApiClient _apiClient;

        public _DefaultTestimonialComponentPartial(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiClient.GetAsync<List<ResultTestimonialDto>>("api/Testimonial");
            return View(values ?? new List<ResultTestimonialDto>());
        }
    }
}