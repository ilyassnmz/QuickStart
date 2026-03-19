using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Clients;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class ClientController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public ClientController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultClientDto>>("api/Client");
            return View(values ?? new List<ResultClientDto>());
        }

        [HttpGet]
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDto model)
        {
            var ok = await _apiClient.PostAsync("api/Client", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateClient(int id)
        {
            var value = await _apiClient.GetAsync<UpdateClientDto>($"api/Client/{id}");
            return View(value ?? new UpdateClientDto { ClientId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(UpdateClientDto model)
        {
            var ok = await _apiClient.PutAsync("api/Client", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteClient(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Client/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
