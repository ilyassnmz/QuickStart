using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.DTOs.FAQDTOs;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public FAQController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FAQList()
        {
            var values = _context.FAQs
                .Select(x => new ResultFAQDto
                {
                    FAQId = x.FAQId,
                    Question = x.Question,
                    Answer = x.Answer,
                    Order = x.Order,
                    IsActive = x.IsActive
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.FAQs.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultFAQDto
            {
                FAQId = value.FAQId,
                Question = value.Question,
                Answer = value.Answer,
                Order = value.Order,
                IsActive = value.IsActive
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFAQ(CreateFAQDto createDto)
        {
            var faq = new FAQ
            {
                Question = createDto.Question,
                Answer = createDto.Answer,
                Order = createDto.Order,
                IsActive = createDto.IsActive
            };

            _context.FAQs.Add(faq);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateFAQ(UpdateFAQDto updateDto)
        {
            var faq = new FAQ
            {
                FAQId = updateDto.FAQId,
                Question = updateDto.Question,
                Answer = updateDto.Answer,
                Order = updateDto.Order,
                IsActive = updateDto.IsActive
            };

            _context.FAQs.Update(faq);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFAQ(int id)
        {
            var value = _context.FAQs.Find(id);
            if (value == null)
                return NotFound();

            _context.FAQs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}