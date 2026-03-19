using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Slider;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public SliderController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultSliderDto>>("api/Slider");
            return View(values ?? new List<ResultSliderDto>());
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto model)
        {
            var ok = await _apiClient.PostAsync("api/Slider", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _apiClient.GetAsync<UpdateSliderDto>($"api/Slider/{id}");
            return View(value ?? new UpdateSliderDto { SliderId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto model)
        {
            var ok = await _apiClient.PutAsync("api/Slider", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Slider/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
