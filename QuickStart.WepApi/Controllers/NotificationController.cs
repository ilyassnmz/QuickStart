using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.NotificationDTOs;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
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
        public IActionResult NotificationList()
        {
            var values = _context.Notifications
                .Include(x => x.NotificationType)
                .Select(x => new ResultNotificationDto
                {
                    NotificationId = x.NotificationId,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    IsRead = x.IsRead,
                    NotificationTypeId = x.NotificationTypeId,
                    NotificationTypeName = x.NotificationType.Name
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Notifications
                .Include(x => x.NotificationType)
                .FirstOrDefault(x => x.NotificationId == id);

            if (value == null)
                return NotFound();

            var result = new ResultNotificationDto
            {
                NotificationId = value.NotificationId,
                Title = value.Title,
                Content = value.Content,
                CreatedAt = value.CreatedAt,
                IsRead = value.IsRead,
                NotificationTypeId = value.NotificationTypeId,
                NotificationTypeName = value.NotificationType?.Name
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createDto)
        {
            var notification = new Notification
            {
                Title = createDto.Title,
                Content = createDto.Content,
                CreatedAt = DateTime.Now,
                IsRead = false,
                NotificationTypeId = createDto.NotificationTypeId
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateDto)
        {
            var notification = new Notification
            {
                NotificationId = updateDto.NotificationId,
                Title = updateDto.Title,
                Content = updateDto.Content,
                CreatedAt = updateDto.CreatedAt,
                IsRead = updateDto.IsRead,
                NotificationTypeId = updateDto.NotificationTypeId
            };

            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
                return NotFound();

            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}