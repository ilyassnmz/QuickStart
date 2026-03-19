using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Message;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public MessageController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultMessageDto>>("api/Message");
            return View(values ?? new List<ResultMessageDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateMessage()
        {
            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto model)
        {
            var ok = await _apiClient.PostAsync("api/Message", model);
            if (ok) return RedirectToAction("Index");

            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var value = await _apiClient.GetAsync<UpdateMessageDto>($"api/Message/{id}");
            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View(value ?? new UpdateMessageDto { MessageId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto model)
        {
            var ok = await _apiClient.PutAsync("api/Message", model);
            if (ok) return RedirectToAction("Index");

            var types = await _apiClient.GetAsync<List<ResultNotificationTypeDto>>("api/NotificationType");
            ViewBag.NotificationTypes = types ?? new List<ResultNotificationTypeDto>();
            return View(model);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Message/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
