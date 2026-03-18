using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;

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
            var values = _context.Sliders.ToList();
            return Ok(values);
        }

        [HttpGet("SliderCount")]
        public IActionResult SliderCount()
        {
            var value = _context.Sliders.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var slider = _context.Sliders.Find(id);
            return Ok(slider);
        }

        [HttpPost]
        public IActionResult CreateSlider(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateSlider(Slider slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            var value = _context.Sliders.Find(id);
            _context.Sliders.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}