using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.About;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public AboutController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultAboutDto>>("api/About");
            return View(values ?? new List<ResultAboutDto>());
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto model)
        {
            var ok = await _apiClient.PostAsync("api/About", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _apiClient.GetAsync<UpdateAboutDto>($"api/About/{id}");
            return View(value ?? new UpdateAboutDto { AboutId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            var ok = await _apiClient.PutAsync("api/About", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/About/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
