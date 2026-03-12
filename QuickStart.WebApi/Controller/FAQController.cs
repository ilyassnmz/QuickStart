using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
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
            var values = _context.FAQs.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.FAQs.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFAQ(FAQ faq)
        {
            _context.FAQs.Add(faq);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateFAQ(FAQ faq)
        {
            _context.FAQs.Update(faq);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFAQ(int id)
        {
            var value = _context.FAQs.Find(id);
            _context.FAQs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}