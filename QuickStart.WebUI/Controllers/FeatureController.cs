using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Feature;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public FeatureController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultFeatureDto>>("api/Feature");
            return View(values ?? new List<ResultFeatureDto>());
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto model)
        {
            var ok = await _apiClient.PostAsync("api/Feature", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _apiClient.GetAsync<UpdateFeatureDto>($"api/Feature/{id}");
            return View(value ?? new UpdateFeatureDto { FeatureId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto model)
        {
            var ok = await _apiClient.PutAsync("api/Feature", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Feature/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
