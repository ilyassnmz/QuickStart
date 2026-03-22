using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.MessageDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/Message")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public MessagesController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Messages.Select(x => new ResultMessageDto
            {
                Id = x.MessageId,
                Name = x.Name,
                Email = x.Email,
                Subject = x.Subject,
                Content = x.Content
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateMessageDto dto)
        {
            var entity = new Message { Name = dto.Name, Email = dto.Email, Subject = dto.Subject, Content = dto.Content };
            _context.Messages.Add(entity);
            _context.SaveChanges();
            return Ok("Mesaj gönderildi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateMessageDto dto)
        {
            var value = _context.Messages.Find(dto.Id);
            value.Name = dto.Name; value.Email = dto.Email; value.Subject = dto.Subject; value.Content = dto.Content;
            _context.SaveChanges();
            return Ok("Mesaj güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Messages.Find(id);
            return Ok(new ResultMessageDto { Id = x.MessageId, Name = x.Name, Email = x.Email, Subject = x.Subject, Content = x.Content });
        }
    }
}
