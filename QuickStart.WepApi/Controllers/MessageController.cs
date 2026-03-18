using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
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
            var values = _context.Messages.ToList();
            return Ok(values);
        }

        [HttpGet("MessageCount")]
        public IActionResult MessageCount()
        {
            var value = _context.Messages.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var message = _context.Messages.Find(id);
            return Ok(message);
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}