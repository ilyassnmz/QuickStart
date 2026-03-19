using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.SubscribeDTOs;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public SubscribeController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _context.Subscribes
                .Select(x => new ResultSubscribeDto
                {
                    SubscribeId = x.SubscribeId,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt,
                    IsActive = x.IsActive
                })
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Subscribes.Find(id);
            if (value == null) return NotFound();

            return Ok(new ResultSubscribeDto
            {
                SubscribeId = value.SubscribeId,
                Email = value.Email,
                CreatedAt = value.CreatedAt,
                IsActive = value.IsActive
            });
        }

        [HttpPost]
        public IActionResult CreateSubscribe(CreateSubscribeDto createDto)
        {
            var entity = new Subscribe
            {
                Email = createDto.Email,
                IsActive = createDto.IsActive,
                CreatedAt = DateTime.Now
            };

            _context.Subscribes.Add(entity);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDto updateDto)
        {
            var entity = new Subscribe
            {
                SubscribeId = updateDto.SubscribeId,
                Email = updateDto.Email,
                IsActive = updateDto.IsActive,
                CreatedAt = updateDto.CreatedAt
            };

            _context.Subscribes.Update(entity);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _context.Subscribes.Find(id);
            if (value == null) return NotFound();

            _context.Subscribes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
