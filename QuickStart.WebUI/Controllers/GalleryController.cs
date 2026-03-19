using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Gallery;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class GalleryController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public GalleryController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultGalleryDto>>("api/Gallery");
            return View(values ?? new List<ResultGalleryDto>());
        }

        [HttpGet]
        public IActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryDto model)
        {
            var ok = await _apiClient.PostAsync("api/Gallery", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGallery(int id)
        {
            var value = await _apiClient.GetAsync<UpdateGalleryDto>($"api/Gallery/{id}");
            return View(value ?? new UpdateGalleryDto { GalleryId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGallery(UpdateGalleryDto model)
        {
            var ok = await _apiClient.PutAsync("api/Gallery", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteGallery(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Gallery/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
