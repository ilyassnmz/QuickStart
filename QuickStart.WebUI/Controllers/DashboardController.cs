using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public DashboardController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TestimonialCount = await _apiClient.GetAsync<int>("api/Testimonial/count");
            ViewBag.ServiceCount = await _apiClient.GetAsync<int>("api/Service/count");
            return View();
        }
    }
}
