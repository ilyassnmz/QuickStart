using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Notification;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public NotificationController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultNotificaitonWithNotificationTypeDto>>(
                "api/Notification/GetNotificationListwithNotificationType");
            return View(values ?? new List<ResultNotificaitonWithNotificationTypeDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateNotification()
        {
            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto model)
        {
            var ok = await _apiClient.PostAsync("api/Notification", model);
            if (ok) return RedirectToAction("Index");

            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var value = await _apiClient.GetAsync<UpdateNotificationDto>($"api/Notification/{id}");
            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View(value ?? new UpdateNotificationDto { NotificationId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto model)
        {
            var ok = await _apiClient.PutAsync("api/Notification", model);
            if (ok) return RedirectToAction("Index");

            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View(model);
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Notification/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
