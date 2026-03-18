using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.TestimonialDTOs;
using QuickStart.WepApi.Entities;
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
            var values = _context.Testimonials
                .Select(x => new ResultTestimonialDto
                {
                    TestimonialId = x.TestimonialId,
                    FullName = x.FullName,
                    Title = x.Title,
                    Descriptions = x.Description,
                    Rate = x.Rate
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultTestimonialDto
            {
                TestimonialId = value.TestimonialId,
                FullName = value.FullName,
                Title = value.Title,
                Descriptions = value.Description,
                Rate = value.Rate
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createDto)
        {
            var testimonial = new Testimonial
            {
                FullName = createDto.FullName,
                Title = createDto.Title,
                Description = createDto.Descriptions,
                Rate = createDto.Rate
            };

            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateDto)
        {
            var testimonial = new Testimonial
            {
                TestimonialId = updateDto.TestimonialId,
                FullName = updateDto.FullName,
                Title = updateDto.Title,
                Description = updateDto.Descriptions,
                Rate = updateDto.Rate
            };

            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null)
                return NotFound();

            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}