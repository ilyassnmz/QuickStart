using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.PricingDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/Pricing")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public PricingsController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Pricings.Select(x => new ResultPricingDto
            {
                Id = x.PricingId,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Period = x.Period,
                IsFeatured = x.IsFeatured,
                Features = x.Features
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreatePricingDto dto)
        {
            var entity = new Pricing { Name = dto.Name, Description = dto.Description, Price = dto.Price, Period = dto.Period, IsFeatured = dto.IsFeatured, Features = dto.Features };
            _context.Pricings.Add(entity);
            _context.SaveChanges();
            return Ok("Fiyatlandırma eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Pricings.Find(id);
            _context.Pricings.Remove(value);
            _context.SaveChanges();
            return Ok("Fiyatlandırma silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdatePricingDto dto)
        {
            var value = _context.Pricings.Find(dto.Id);
            value.Name = dto.Name; value.Description = dto.Description; value.Price = dto.Price; value.Period = dto.Period; value.IsFeatured = dto.IsFeatured; value.Features = dto.Features;
            _context.SaveChanges();
            return Ok("Fiyatlandırma güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Pricings.Find(id);
            return Ok(new ResultPricingDto { Id = x.PricingId, Name = x.Name, Description = x.Description, Price = x.Price, Period = x.Period, IsFeatured = x.IsFeatured, Features = x.Features });
        }
    }
}
