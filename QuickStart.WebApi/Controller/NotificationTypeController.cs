using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WebApi.Context;
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
            var values = _context.NotificationTypes.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateNotificationType(NotificationType notificationType)
        {
            _context.NotificationTypes.Add(notificationType);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateNotificationType(NotificationType notificationType)
        {
            _context.NotificationTypes.Update(notificationType);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotificationType(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            _context.NotificationTypes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}