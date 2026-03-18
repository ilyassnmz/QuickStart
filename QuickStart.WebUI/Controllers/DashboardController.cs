using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7051/api/Testimonial/TestimonialCount");
            var JsonData=await responseMessage.Content.ReadAsStringAsync();
            ViewBag.TestimonialCount = JsonData;

            var responseMessage1 = await client.GetAsync("https://localhost:7051/api/Service/ServiceCount");
            var JsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ServiceCount = JsonData1;
            return View();
        }
    }
}
