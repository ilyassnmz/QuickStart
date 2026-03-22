using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.FeatureDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public FeaturesController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Features.Select(x => new ResultFeatureDto
            {
                Id = x.FeatureId,
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon,
                ImageUrl = x.ImageUrl
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDto dto)
        {
            var entity = new Feature { Title = dto.Title, Description = dto.Description, Icon = dto.Icon, ImageUrl = dto.ImageUrl };
            _context.Features.Add(entity);
            _context.SaveChanges();
            return Ok("Özellik eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Özellik silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDto dto)
        {
            var value = _context.Features.Find(dto.Id);
            value.Title = dto.Title; value.Description = dto.Description; value.Icon = dto.Icon; value.ImageUrl = dto.ImageUrl;
            _context.SaveChanges();
            return Ok("Özellik güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Features.Find(id);
            return Ok(new ResultFeatureDto { Id = x.FeatureId, Title = x.Title, Description = x.Description, Icon = x.Icon, ImageUrl = x.ImageUrl });
        }
    }
}
