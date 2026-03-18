using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.ServiceDTOs;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
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
                    IconUrl = x.IconUrl
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultServiceDto
            {
                ServiceId = value.ServiceId,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createDto)
        {
            var service = new Service
            {
                Title = createDto.Title,
                Description = createDto.Description,
                IconUrl = createDto.IconUrl
            };

            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateDto)
        {
            var service = new Service
            {
                ServiceId = updateDto.ServiceId,
                Title = updateDto.Title,
                Description = updateDto.Description,
                IconUrl = updateDto.IconUrl
            };

            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
                return NotFound();

            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}