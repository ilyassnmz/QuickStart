using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.FaqDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/Faq")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public FaqsController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Faqs.Select(x => new ResultFaqDto
            {
                Id = x.FaqId,
                Question = x.Question,
                Answer = x.Answer
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateFaqDto dto)
        {
            var entity = new FAQ { Question = dto.Question, Answer = dto.Answer };
            _context.Faqs.Add(entity);
            _context.SaveChanges();
            return Ok("S.S.S. eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Faqs.Find(id);
            _context.Faqs.Remove(value);
            _context.SaveChanges();
            return Ok("S.S.S. silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFaqDto dto)
        {
            var value = _context.Faqs.Find(dto.Id);
            value.Question = dto.Question; value.Answer = dto.Answer;
            _context.SaveChanges();
            return Ok("S.S.S. güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Faqs.Find(id);
            return Ok(new ResultFaqDto { Id = x.FaqId, Question = x.Question, Answer = x.Answer });
        }
    }
}
