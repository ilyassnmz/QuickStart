using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.ClientDTOs;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ClientController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ClientList()
        {
            var values = _context.Clients
                .Select(x => new ResultClientDto
                {
                    ClientId = x.ClientId,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    WebsiteUrl = x.WebsiteUrl,
                    Order = x.Order,
                    IsActive = x.IsActive
                })
                .OrderBy(x => x.Order)
                .ToList();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Clients.Find(id);
            if (value == null) return NotFound();

            return Ok(new ResultClientDto
            {
                ClientId = value.ClientId,
                Name = value.Name,
                LogoUrl = value.LogoUrl,
                WebsiteUrl = value.WebsiteUrl,
                Order = value.Order,
                IsActive = value.IsActive
            });
        }

        [HttpPost]
        public IActionResult CreateClient(CreateClientDto createDto)
        {
            var entity = new Client
            {
                Name = createDto.Name,
                LogoUrl = createDto.LogoUrl,
                WebsiteUrl = createDto.WebsiteUrl,
                Order = createDto.Order,
                IsActive = createDto.IsActive
            };

            _context.Clients.Add(entity);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateClient(UpdateClientDto updateDto)
        {
            var entity = new Client
            {
                ClientId = updateDto.ClientId,
                Name = updateDto.Name,
                LogoUrl = updateDto.LogoUrl,
                WebsiteUrl = updateDto.WebsiteUrl,
                Order = updateDto.Order,
                IsActive = updateDto.IsActive
            };

            _context.Clients.Update(entity);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var value = _context.Clients.Find(id);
            if (value == null) return NotFound();

            _context.Clients.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
