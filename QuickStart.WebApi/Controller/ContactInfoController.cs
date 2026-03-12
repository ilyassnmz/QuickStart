using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApi.Context;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ContactInfoController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactInfoList()
        {
            var values = _context.ContactInfos.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.ContactInfos.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Update(contactInfo);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactInfo(int id)
        {
            var value = _context.ContactInfos.Find(id);
            _context.ContactInfos.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}