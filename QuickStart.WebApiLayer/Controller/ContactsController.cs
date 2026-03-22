using Microsoft.AspNetCore.Mvc;
using QuickStart.WebApiLayer.Contexts;
using QuickStart.WebApiLayer.DTOs.ContactDTOs;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ContactsController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _context.Contacts.Select(x => new ResultContactDto
            {
                Id = x.ContactId,
                Title = x.Title,
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto dto)
        {
            var entity = new Contact { Title = dto.Title, Description = dto.Description, Address = dto.Address, Phone = dto.Phone, Email = dto.Email };
            _context.Contacts.Add(entity);
            _context.SaveChanges();
            return Ok("İletişim eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("İletişim silindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto dto)
        {
            var value = _context.Contacts.Find(dto.Id);
            value.Title = dto.Title; value.Description = dto.Description; value.Address = dto.Address; value.Phone = dto.Phone; value.Email = dto.Email;
            _context.SaveChanges();
            return Ok("İletişim güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var x = _context.Contacts.Find(id);
            return Ok(new ResultContactDto { Id = x.ContactId, Title = x.Title, Description = x.Description, Address = x.Address, Phone = x.Phone, Email = x.Email });
        }
    }
}
