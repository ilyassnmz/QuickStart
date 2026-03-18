using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.DTOs.ContactInfoDTOs;

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
            var values = _context.ContactInfos
                .Select(x => new ResultContactInfoDto
                {
                    ContactInfoId = x.ContactInfoId,
                    Address = x.Address,
                    Phone = x.Phone,
                    Email = x.Email,
                    MapLocation = x.MapLocation
                })
                .ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.ContactInfos.Find(id);
            if (value == null)
                return NotFound();

            var result = new ResultContactInfoDto
            {
                ContactInfoId = value.ContactInfoId,
                Address = value.Address,
                Phone = value.Phone,
                Email = value.Email,
                MapLocation = value.MapLocation
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContactInfo(CreateContactInfoDto createDto)
        {
            var contactInfo = new ContactInfo
            {
                Address = createDto.Address,
                Phone = createDto.Phone,
                Email = createDto.Email,
                MapLocation = createDto.MapLocation
            };

            _context.ContactInfos.Add(contactInfo);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateContactInfo(UpdateContactInfoDto updateDto)
        {
            var contactInfo = new ContactInfo
            {
                ContactInfoId = updateDto.ContactInfoId,
                Address = updateDto.Address,
                Phone = updateDto.Phone,
                Email = updateDto.Email,
                MapLocation = updateDto.MapLocation
            };

            _context.ContactInfos.Update(contactInfo);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactInfo(int id)
        {
            var value = _context.ContactInfos.Find(id);
            if (value == null)
                return NotFound();

            _context.ContactInfos.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}