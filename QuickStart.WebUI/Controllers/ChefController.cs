using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Chef;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class ChefController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public ChefController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultChefDto>>("api/Chef");
            return View(values ?? new List<ResultChefDto>());
        }

        [HttpGet]
        public IActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDto model)
        {
            var ok = await _apiClient.PostAsync("api/Chef", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateChef(int id)
        {
            var value = await _apiClient.GetAsync<UpdateChefDto>($"api/Chef/{id}");
            return View(value ?? new UpdateChefDto { ChefId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDto model)
        {
            var ok = await _apiClient.PutAsync("api/Chef", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteChef(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Chef/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
