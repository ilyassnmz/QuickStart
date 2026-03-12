using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Dto;
using QuickStart.WebApi.Dto.NotificationDto;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public NotificationController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetNotificationList()
        {
            var values = _context.Notifications
                .Select(x => new ResultNotificationDto
                {
                    NotificationId = x.NotificationId,
                    Title = x.Title,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    NotificationTypeId = x.NotificationTypeId
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var value = _context.Notifications
                .Where(x => x.NotificationId == id)
                .Select(x => new ResultNotificationDto
                {
                    NotificationId = x.NotificationId,
                    Title = x.Title,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    NotificationTypeId = x.NotificationTypeId
                })
                .FirstOrDefault();

            if (value == null)
                return NotFound("Bildirim bulunamadı");

            return Ok(value);
        }

        [HttpGet("GetNotificationListWithNotificationType")]
        public IActionResult GetNotificationListWithNotificationType()
        {
            var values = _context.Notifications
                .Include(x => x.NotificationType)
                .Select(x => new ResultNotificationWithNotificationTypeDto
                {
                    NotificationId = x.NotificationId,
                    Title = x.Title,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    NotificationTypeName = x.NotificationType.Name
                })
                .ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = new Notification
            {
                Title = createNotificationDto.Title,
                Content = createNotificationDto.Content,
                IsRead = createNotificationDto.IsRead,
                NotificationTypeId = createNotificationDto.NotificationTypeId
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = new Notification
            {
                NotificationId = updateNotificationDto.NotificationId,
                Title = updateNotificationDto.Title,
                Content = updateNotificationDto.Content,
                IsRead = updateNotificationDto.IsRead,
                NotificationTypeId = updateNotificationDto.NotificationTypeId
            };

            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
                return NotFound("Bildirim bulunamadı");

            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}