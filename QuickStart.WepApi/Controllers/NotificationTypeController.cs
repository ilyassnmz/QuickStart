using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.NotificationTypeDTOs;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypeController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public NotificationTypeController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationTypeList()
        {
            var values = _context.NotificationTypes
                .Select(x => new ResultNotificationTypeDto
                {
                    NotificationTypeId = x.NotificationTypeId,
                    Name = x.Name
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultNotificationTypeDto
            {
                NotificationTypeId = value.NotificationTypeId,
                Name = value.Name
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateNotificationType(CreateNotificationTypeDto createDto)
        {
            var notificationType = new NotificationType
            {
                Name = createDto.Name
            };

            _context.NotificationTypes.Add(notificationType);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateNotificationType(UpdateNotificationTypeDto updateDto)
        {
            var notificationType = new NotificationType
            {
                NotificationTypeId = updateDto.NotificationTypeId,
                Name = updateDto.Name
            };

            _context.NotificationTypes.Update(notificationType);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotificationType(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            if (value == null)
                return NotFound();

            _context.NotificationTypes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}