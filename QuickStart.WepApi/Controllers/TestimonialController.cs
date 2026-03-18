using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public TestimonialController(QuickStartContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult TestimonialList()
        {
            var value=_context.Testimonials.ToList();
            return Ok(value);
        }

        [HttpGet("TestimonialCount")]

        public IActionResult TestimonialCount()
        {
            var value = _context.Testimonials.Count();
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti :)");
        }

        [HttpPut]

        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
