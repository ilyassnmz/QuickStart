using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.TestimonialDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public TestimonialsController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Testimonials.Select(x => new ResultTestimonialDto
            {
                Id = x.TestimonialId,
                Name = x.Name,
                Role = x.Role,
                ImageUrl = x.ImageUrl,
                Content = x.Content
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDto dto)
        {
            var entity = new Testimonial { Name = dto.Name, Role = dto.Role, ImageUrl = dto.ImageUrl, Content = dto.Content };
            _context.Testimonials.Add(entity);
            _context.SaveChanges();
            return Ok("Referans eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Referans silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto dto)
        {
            var value = _context.Testimonials.Find(dto.Id);
            value.Name = dto.Name; value.Role = dto.Role; value.ImageUrl = dto.ImageUrl; value.Content = dto.Content;
            _context.SaveChanges();
            return Ok("Referans güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Testimonials.Find(id);
            return Ok(new ResultTestimonialDto { Id = x.TestimonialId, Name = x.Name, Role = x.Role, ImageUrl = x.ImageUrl, Content = x.Content });
        }
    }
}
