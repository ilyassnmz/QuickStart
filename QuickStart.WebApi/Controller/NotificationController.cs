using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WebApi.Context;

namespace QuickStart.WebApi.Controller
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
            var values = _context.Notifications.ToList();
            return Ok(values);
        }
        [HttpGet("2")]
        public IActionResult GetNotificationListwithNotificationType()
        {
            var values = _context.Notifications.Include(X => X.NotificationType).ToList();
            return Ok(values);

        }
    }
}
