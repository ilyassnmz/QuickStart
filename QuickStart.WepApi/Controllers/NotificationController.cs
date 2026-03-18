using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Dto;

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
        public IActionResult GetNotificationList()
        {
            var values=_context.Notifications.ToList();
            return Ok(values);
        }

        [HttpGet("2")]
        public IActionResult GetNotificationListwithNotificationType2()
        {
            var values = _context.Notifications.Include(X=>X.NotificationType).ToList();
            return Ok(values);
        }

        [HttpGet("GetNotificationListwithNotificationType")]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.Include(x => x.NotificationType).Select(x => new ResultNotificationWithNotificationTypeDto
            {
                NotificationId = x.NotificationId,
                Title = x.Title,
                Content = x.Content,
                IsRead = x.IsRead,
                NotificationTypeName = x.NotificationType.Name
            });
            return Ok(values);
        }
    }
}
