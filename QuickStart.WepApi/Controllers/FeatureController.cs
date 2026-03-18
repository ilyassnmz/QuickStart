using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.DTOs.FeatureDTOs;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public FeatureController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features
                .Select(x => new ResultFeatureDto
                {
                    FeatureId = x.FeatureId,
                    Title = x.Title,
                    Description = x.Description,
                    Icon = x.Icon
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultFeatureDto
            {
                FeatureId = value.FeatureId,
                Title = value.Title,
                Description = value.Description,
                Icon = value.Icon
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createDto)
        {
            var feature = new Feature
            {
                Title = createDto.Title,
                Description = createDto.Description,
                Icon = createDto.Icon
            };

            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateDto)
        {
            var feature = new Feature
            {
                FeatureId = updateDto.FeatureId,
                Title = updateDto.Title,
                Description = updateDto.Description,
                Icon = updateDto.Icon
            };

            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
                return NotFound();

            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}