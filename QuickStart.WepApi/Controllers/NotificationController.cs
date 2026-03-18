using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
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
            var values = _context.Notifications.ToList();
            return Ok(values);
        }

        [HttpGet("NotificationCount")]
        public IActionResult NotificationCount()
        {
            var value = _context.Notifications.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notification = _context.Notifications.Find(id);
            return Ok(notification);
        }

        [HttpPost]
        public IActionResult CreateNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}