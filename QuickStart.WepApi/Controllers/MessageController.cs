using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Dto.MessageDTOs;
using QuickStart.WepApi.DTOs.MessageDTOs;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public MessageController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages
                .Include(x => x.NotificationType)
                .Select(x => new ResultMessageDto
                {
                    MessageId = x.MessageId,
                    Name = x.Name,
                    Email = x.Email,
                    Subject = x.Subject,
                    Content = x.Content,
                    SendDate = x.SendDate,
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
            var value = _context.Messages
                .Include(x => x.NotificationType)
                .FirstOrDefault(x => x.MessageId == id);

            if (value == null)
                return NotFound();

            var result = new ResultMessageDto
            {
                MessageId = value.MessageId,
                Name = value.Name,
                Email = value.Email,
                Subject = value.Subject,
                Content = value.Content,
                SendDate = value.SendDate,
                IsRead = value.IsRead,
                NotificationTypeId = value.NotificationTypeId,
                NotificationTypeName = value.NotificationType?.Name
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createDto)
        {
            var message = new Message
            {
                Name = createDto.Name,
                Email = createDto.Email,
                Subject = createDto.Subject,
                Content = createDto.Content,
                SendDate = DateTime.Now,
                IsRead = false,
                NotificationTypeId = createDto.NotificationTypeId
            };

            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateDto)
        {
            var message = new Message
            {
                MessageId = updateDto.MessageId,
                Name = updateDto.Name,
                Email = updateDto.Email,
                Subject = updateDto.Subject,
                Content = updateDto.Content,
                SendDate = updateDto.SendDate,
                IsRead = updateDto.IsRead,
                NotificationTypeId = updateDto.NotificationTypeId
            };

            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
                return NotFound();

            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}