using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Dto;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
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
                    ImageUrl = x.ImageUrl,
                    IsActive = x.IsActive
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Sliders
                .Where(x => x.SliderId == id)
                .Select(x => new ResultSliderDto
                {
                    SliderId = x.SliderId,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    IsActive = x.IsActive
                })
                .FirstOrDefault();

            if (value == null)
                return NotFound("Slider bulunamadı");

            return Ok(value);
        }

        [HttpGet("ActiveSliders")]
        public IActionResult GetActiveSliders()
        {
            var values = _context.Sliders
                .Where(x => x.IsActive == true)
                .Select(x => new ResultSliderDto
                {
                    SliderId = x.SliderId,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    IsActive = x.IsActive
                })
                .ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createDto)
        {
            var slider = new Slider
            {
                Title = createDto.Title,
                Description = createDto.Description,
                ImageUrl = createDto.ImageUrl,
                IsActive = createDto.IsActive
            };

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateDto)
        {
            var slider = new Slider
            {
                SliderId = updateDto.SliderId,
                Title = updateDto.Title,
                Description = updateDto.Description,
                ImageUrl = updateDto.ImageUrl,
                IsActive = updateDto.IsActive
            };

            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _context.Sliders.Find(id);
            if (value == null)
                return NotFound("Slider bulunamadı");

            _context.Sliders.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut("ToggleStatus/{id}")]
        public IActionResult ToggleSliderStatus(int id)
        {
            var slider = _context.Sliders.Find(id);
            if (slider == null)
                return NotFound("Slider bulunamadı");

            slider.IsActive = !slider.IsActive;
            _context.SaveChanges();

            return Ok($"Slider durumu değiştirildi. Yeni durum: {(slider.IsActive ? "Aktif" : "Pasif")}");
        }
    }
}