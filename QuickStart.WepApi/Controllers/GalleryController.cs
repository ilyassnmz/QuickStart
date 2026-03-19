using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.DTOs.GalleryDTOs;
using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public GalleryController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GalleryList()
        {
            var values = _context.Galleries
                .Select(x => new ResultGalleryDto
                {
                    GalleryId = x.GalleryId,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
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
            var value = _context.Galleries.Find(id);
            if (value == null) return NotFound();

            return Ok(new ResultGalleryDto
            {
                GalleryId = value.GalleryId,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                Order = value.Order,
                IsActive = value.IsActive
            });
        }

        [HttpPost]
        public IActionResult CreateGallery(CreateGalleryDto createDto)
        {
            var entity = new Gallery
            {
                Title = createDto.Title,
                ImageUrl = createDto.ImageUrl,
                Order = createDto.Order,
                IsActive = createDto.IsActive
            };

            _context.Galleries.Add(entity);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateGallery(UpdateGalleryDto updateDto)
        {
            var entity = new Gallery
            {
                GalleryId = updateDto.GalleryId,
                Title = updateDto.Title,
                ImageUrl = updateDto.ImageUrl,
                Order = updateDto.Order,
                IsActive = updateDto.IsActive
            };

            _context.Galleries.Update(entity);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            if (value == null) return NotFound();

            _context.Galleries.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
