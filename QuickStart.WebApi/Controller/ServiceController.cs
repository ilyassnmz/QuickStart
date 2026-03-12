using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Dto;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ServiceController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services
                .Select(x => new ResultServiceDto
                {
                    ServiceId = x.ServiceId,
                    Title = x.Title,
                    Description = x.Description,
                    Icon = x.Icon
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("ServiceCount")]
        public IActionResult ServiceCount()
        {
            var value = _context.Services.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Services
                .Where(x => x.ServiceId == id)
                .Select(x => new ResultServiceDto
                {
                    ServiceId = x.ServiceId,
                    Title = x.Title,
                    Description = x.Description,
                    Icon = x.Icon
                })
                .FirstOrDefault();

            if (value == null)
                return NotFound("Servis bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createDto)
        {
            var service = new Service
            {
                Title = createDto.Title,
                Description = createDto.Description,
                Icon = createDto.Icon
            };

            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateDto)
        {
            var service = new Service
            {
                ServiceId = updateDto.ServiceId,
                Title = updateDto.Title,
                Description = updateDto.Description,
                Icon = updateDto.Icon
            };

            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
                return NotFound("Servis bulunamadı");

            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}