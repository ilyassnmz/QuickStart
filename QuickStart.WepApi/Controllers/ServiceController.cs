using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public ServiceController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpGet("ServiceCount")]
        public IActionResult ServiceCount()
        {
            var value = _context.Services.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _context.Services.Find(id);
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}