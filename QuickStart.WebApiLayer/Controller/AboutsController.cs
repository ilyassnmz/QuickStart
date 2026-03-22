using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.AboutDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public AboutsController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Abouts.Select(x => new ResultAboutDto
            {
                Id = x.AboutId,
                Title = x.Title,
                Description = x.Description,
                Images = x.Images
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto dto)
        {
            var entity = new About { Title = dto.Title, Description = dto.Description, Images = dto.Images };
            _context.Abouts.Add(entity);
            _context.SaveChanges();
            return Ok("Hakkımızda eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Hakkımızda silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto dto)
        {
            var value = _context.Abouts.Find(dto.Id);
            value.Title = dto.Title; value.Description = dto.Description; value.Images = dto.Images;
            _context.SaveChanges();
            return Ok("Hakkımızda güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Abouts.Find(id);
            return Ok(new ResultAboutDto { Id = x.AboutId, Title = x.Title, Description = x.Description, Images = x.Images });
        }
    }
}
