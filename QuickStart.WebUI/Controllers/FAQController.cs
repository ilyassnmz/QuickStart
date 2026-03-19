using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.FAQ;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class FAQController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public FAQController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultFAQDto>>("api/FAQ");
            return View(values ?? new List<ResultFAQDto>());
        }

        [HttpGet]
        public IActionResult CreateFAQ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFAQ(CreateFAQDto model)
        {
            var ok = await _apiClient.PostAsync("api/FAQ", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFAQ(int id)
        {
            var value = await _apiClient.GetAsync<UpdateFAQDto>($"api/FAQ/{id}");
            return View(value ?? new UpdateFAQDto { FAQId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFAQ(UpdateFAQDto model)
        {
            var ok = await _apiClient.PutAsync("api/FAQ", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteFAQ(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/FAQ/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
