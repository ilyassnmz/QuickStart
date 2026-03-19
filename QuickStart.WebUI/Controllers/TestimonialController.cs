using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.Testionials;

namespace QuickStart.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public TestimonialController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultTestimonialDto>>("api/Testimonial");
            return View(values ?? new List<ResultTestimonialDto>());
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
        {
            var ok = await _apiClient.PostAsync("api/Testimonial", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _apiClient.GetAsync<UpdateTestimonialDto>($"api/Testimonial/{id}");
            return View(value ?? new UpdateTestimonialDto { testimonialId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
            var ok = await _apiClient.PutAsync("api/Testimonial", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/Testimonial/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
