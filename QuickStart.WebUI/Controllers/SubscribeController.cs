using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Subscribe;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public SubscribeController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultSubscribeDto>>("api/Subscribe");
            return View(values ?? new List<ResultSubscribeDto>());
        }

        [HttpGet]
        public IActionResult CreateSubscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto model)
        {
            var ok = await _apiClient.PostAsync("api/Subscribe", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubscribe(int id)
        {
            var value = await _apiClient.GetAsync<UpdateSubscribeDto>($"api/Subscribe/{id}");
            return View(value ?? new UpdateSubscribeDto { SubscribeId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDto model)
        {
            var ok = await _apiClient.PutAsync("api/Subscribe", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Subscribe/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
