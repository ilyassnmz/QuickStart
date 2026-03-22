using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.NewsletterDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/Newsletter")]
    [ApiController]
    public class NewslettersController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public NewslettersController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Newsletters.Select(x => new ResultNewsletterDto
            {
                Id = x.NewsletterId,
                Email = x.Email
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateNewsletterDto dto)
        {
            var entity = new Newsletter { Email = dto.Email };
            _context.Newsletters.Add(entity);
            _context.SaveChanges();
            return Ok("Abone olundu");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Newsletters.Find(id);
            _context.Newsletters.Remove(value);
            _context.SaveChanges();
            return Ok("Abonelik silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateNewsletterDto dto)
        {
            var value = _context.Newsletters.Find(dto.Id);
            value.Email = dto.Email;
            _context.SaveChanges();
            return Ok("Abonelik güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Newsletters.Find(id);
            return Ok(new ResultNewsletterDto { Id = x.NewsletterId, Email = x.Email });
        }
    }
}
