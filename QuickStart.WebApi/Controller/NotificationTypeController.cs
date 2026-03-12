using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Dto;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
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
            var value = _context.NotificationTypes
                .Where(x => x.NotificationTypeId == id)
                .Select(x => new ResultNotificationTypeDto
                {
                    NotificationTypeId = x.NotificationTypeId,
                    Name = x.Name
                })
                .FirstOrDefault();

            if (value == null)
                return NotFound("Bildirim tipi bulunamadı");

            return Ok(value);
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
            return Ok("Ekleme işlemi başarılı");
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
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotificationType(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            if (value == null)
                return NotFound("Bildirim tipi bulunamadı");

            _context.NotificationTypes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}