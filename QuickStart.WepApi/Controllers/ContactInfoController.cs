using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
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

        [HttpGet("ContactInfoCount")]
        public IActionResult ContactInfoCount()
        {
            var value = _context.ContactInfos.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            return Ok(contactInfo);
        }

        [HttpPost]
        public IActionResult CreateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Update(contactInfo);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteContactInfo(int id)
        {
            var value = _context.ContactInfos.Find(id);
            _context.ContactInfos.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}