using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Dto.AboutDTOs;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public AboutController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _context.Abouts
                .Select(x => new ResultAboutDto
                {
                    AboutId = x.AboutId,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl1 = x.ImageUrl1
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultAboutDto
            {
                AboutId = value.AboutId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl1 = value.ImageUrl1
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createDto)
        {
            var about = new About
            {
                Title = createDto.Title,
                Description = createDto.Description,
                ImageUrl1 = createDto.ImageUrl1
            };

            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateDto)
        {
            var about = new About
            {
                AboutId = updateDto.AboutId,
                Title = updateDto.Title,
                Description = updateDto.Description,
                ImageUrl1 = updateDto.ImageUrl1
            };

            _context.Abouts.Update(about);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value == null)
                return NotFound();

            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}