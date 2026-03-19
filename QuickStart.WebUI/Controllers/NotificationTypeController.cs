using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.NotificationType;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class NotificationTypeController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public NotificationTypeController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            return View(values ?? new List<ResultNotificationTypeDto>());
        }

        [HttpGet]
        public IActionResult CreateNotificationType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationType(CreateNotificationTypeDto model)
        {
            var ok = await _apiClient.PostAsync("api/NotificationType", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotificationType(int id)
        {
            var value = await _apiClient.GetAsync<UpdateNotificationTypeDto>($"api/NotificationType/{id}");
            return View(value ?? new UpdateNotificationTypeDto { NotificationTypeId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotificationType(UpdateNotificationTypeDto model)
        {
            var ok = await _apiClient.PutAsync("api/NotificationType", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteNotificationType(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/NotificationType/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
