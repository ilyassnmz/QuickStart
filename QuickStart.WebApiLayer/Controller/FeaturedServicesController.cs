using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.FeaturedServiceDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedServicesController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public FeaturedServicesController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.FeaturedServices.Select(x => new ResultFeaturedServiceDto
            {
                Id = x.FeaturedServiceId,
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateFeaturedServiceDto dto)
        {
            var entity = new FeaturedService { Title = dto.Title, Description = dto.Description, Icon = dto.Icon };
            _context.FeaturedServices.Add(entity);
            _context.SaveChanges();
            return Ok("Öne Çıkan Hizmet eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.FeaturedServices.Find(id);
            _context.FeaturedServices.Remove(value);
            _context.SaveChanges();
            return Ok("Öne Çıkan Hizmet silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeaturedServiceDto dto)
        {
            var value = _context.FeaturedServices.Find(dto.Id);
            value.Title = dto.Title; value.Description = dto.Description; value.Icon = dto.Icon;
            _context.SaveChanges();
            return Ok("Öne Çıkan Hizmet güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.FeaturedServices.Find(id);
            return Ok(new ResultFeaturedServiceDto { Id = x.FeaturedServiceId, Title = x.Title, Description = x.Description, Icon = x.Icon });
        }
    }
}
