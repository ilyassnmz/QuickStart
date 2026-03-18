using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
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
            var values = _context.NotificationTypes.ToList();
            return Ok(values);
        }

        [HttpGet("NotificationTypeCount")]
        public IActionResult NotificationTypeCount()
        {
            var value = _context.NotificationTypes.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notificationType = _context.NotificationTypes.Find(id);
            return Ok(notificationType);
        }

        [HttpPost]
        public IActionResult CreateNotificationType(NotificationType notificationType)
        {
            _context.NotificationTypes.Add(notificationType);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateNotificationType(NotificationType notificationType)
        {
            _context.NotificationTypes.Update(notificationType);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteNotificationType(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            _context.NotificationTypes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}