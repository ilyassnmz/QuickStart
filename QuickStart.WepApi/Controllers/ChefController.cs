using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.ChefDTOs;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ChefController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs
                .Select(x => new ResultChefDto
                {
                    ChefId = x.ChefId,
                    FullName = x.FullName,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    InstagramUrl = x.InstagramUrl,
                    LinkedinUrl = x.LinkedinUrl,
                    TwitterUrl = x.TwitterUrl,
                    Order = x.Order,
                    IsActive = x.IsActive
                })
                .OrderBy(x => x.Order)
                .ToList();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Chefs.Find(id);
            if (value == null) return NotFound();

            return Ok(new ResultChefDto
            {
                ChefId = value.ChefId,
                FullName = value.FullName,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                InstagramUrl = value.InstagramUrl,
                LinkedinUrl = value.LinkedinUrl,
                TwitterUrl = value.TwitterUrl,
                Order = value.Order,
                IsActive = value.IsActive
            });
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDto createDto)
        {
            var entity = new Chef
            {
                FullName = createDto.FullName,
                Title = createDto.Title,
                ImageUrl = createDto.ImageUrl,
                InstagramUrl = createDto.InstagramUrl,
                LinkedinUrl = createDto.LinkedinUrl,
                TwitterUrl = createDto.TwitterUrl,
                Order = createDto.Order,
                IsActive = createDto.IsActive
            };

            _context.Chefs.Add(entity);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDto updateDto)
        {
            var entity = new Chef
            {
                ChefId = updateDto.ChefId,
                FullName = updateDto.FullName,
                Title = updateDto.Title,
                ImageUrl = updateDto.ImageUrl,
                InstagramUrl = updateDto.InstagramUrl,
                LinkedinUrl = updateDto.LinkedinUrl,
                TwitterUrl = updateDto.TwitterUrl,
                Order = updateDto.Order,
                IsActive = updateDto.IsActive
            };

            _context.Chefs.Update(entity);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            if (value == null) return NotFound();

            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
