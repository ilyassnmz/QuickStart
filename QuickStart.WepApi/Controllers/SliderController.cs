using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.DTOs.SliderDTOs;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public SliderController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _context.Sliders
                .Select(x => new ResultSliderDto
                {
                    SliderId = x.SliderId,
                    Title = x.Title,
                    Description = x.Description,
                    ImagesUrl = x.ImageUrl,
                    IsActive = x.IsActive
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Sliders.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultSliderDto
            {
                SliderId = value.SliderId,
                Title = value.Title,
                Description = value.Description,
                ImagesUrl = value.ImageUrl,
                IsActive = value.IsActive
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createDto)
        {
            var slider = new Slider
            {
                Title = createDto.Title,
                Description = createDto.Description,
                ImageUrl = createDto.ImagesUrl,
                IsActive = createDto.IsActive
            };

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateDto)
        {
            var slider = new Slider
            {
                SliderId = updateDto.SliderId,
                Title = updateDto.Title,
                Description = updateDto.Description,
                ImageUrl = updateDto.ImagesUrl,
                IsActive = updateDto.IsActive
            };

            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _context.Sliders.Find(id);
            if (value == null)
                return NotFound();

            _context.Sliders.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}