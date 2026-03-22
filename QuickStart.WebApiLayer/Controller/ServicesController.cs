using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.ServiceDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ServicesController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Services.Select(x => new ResultServiceDto
            {
                Id = x.ServiceId,
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateServiceDto dto)
        {
            var entity = new Service { Title = dto.Title, Description = dto.Description, Icon = dto.Icon };
            _context.Services.Add(entity);
            _context.SaveChanges();
            return Ok("Hizmet eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateServiceDto dto)
        {
            var value = _context.Services.Find(dto.Id);
            value.Title = dto.Title; value.Description = dto.Description; value.Icon = dto.Icon;
            _context.SaveChanges();
            return Ok("Hizmet güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Services.Find(id);
            return Ok(new ResultServiceDto { Id = x.ServiceId, Title = x.Title, Description = x.Description, Icon = x.Icon });
        }
    }
}
