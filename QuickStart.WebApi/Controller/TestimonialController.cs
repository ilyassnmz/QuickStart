using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Dto;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
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
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Rate = x.Rate
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("TestimonialCount")]
        public IActionResult TestimonialCount()
        {
            var value = _context.Testimonials.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Testimonials
                .Where(x => x.TestimonialId == id)
                .Select(x => new ResultTestimonialDto
                {
                    TestimonialId = x.TestimonialId,
                    FullName = x.FullName,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Rate = x.Rate
                })
                .FirstOrDefault();

            if (value == null)
                return NotFound("Referans bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createDto)
        {
            var testimonial = new Testimonial
            {
                FullName = createDto.FullName,
                Title = createDto.Title,
                Description = createDto.Description,
                ImageUrl = createDto.ImageUrl,
                Rate = createDto.Rate
            };

            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateDto)
        {
            var testimonial = new Testimonial
            {
                TestimonialId = updateDto.TestimonialId,
                FullName = updateDto.FullName,
                Title = updateDto.Title,
                Description = updateDto.Description,
                ImageUrl = updateDto.ImageUrl,
                Rate = updateDto.Rate
            };

            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null)
                return NotFound("Referans bulunamadı");

            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}