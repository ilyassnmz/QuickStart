using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;

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
            var values = _context.Features.ToList();
            return Ok(values);
        }

        [HttpGet("FeatureCount")]
        public IActionResult FeatureCount()
        {
            var value = _context.Features.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var feature = _context.Features.Find(id);
            return Ok(feature);
        }

        [HttpPost]
        public IActionResult CreateFeature(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}