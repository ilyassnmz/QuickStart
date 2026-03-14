using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QuickStart.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = "https://localhost:7121/api/";

            var endpoints = new[]
            {
                "About", "ContactInfo", "FAQ", "Feature", "Message",
                "Notification", "NotificationType", "Service", "Slider", "Testimonial"
            };

            var counts = new Dictionary<string, int>();

            foreach (var endpoint in endpoints)
            {
                try
                {
                    var responseMessage = await client.GetAsync(baseUrl + endpoint);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var jsonData = await responseMessage.Content.ReadAsStringAsync();
                        var array = JsonSerializer.Deserialize<JsonArray>(jsonData);
                        counts[endpoint] = array?.Count ?? 0;
                    }
                    else
                    {
                        counts[endpoint] = 0;
                    }
                }
                catch
                {
                    counts[endpoint] = 0;
                }
            }

            ViewBag.Counts = counts;
            return View();
        }
    }
}
