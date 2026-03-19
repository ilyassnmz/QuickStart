using Microsoft.AspNetCore.Mvc;
using QuickStart.WebUI.Dtos.ContactInfo;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly Services.ApiClient _apiClient;

        public ContactInfoController(Services.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiClient.GetAsync<List<ResultContactInfoDto>>("api/ContactInfo");
            return View(values ?? new List<ResultContactInfoDto>());
        }

        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactInfo(CreateContactInfoDto model)
        {
            var ok = await _apiClient.PostAsync("api/ContactInfo", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContactInfo(int id)
        {
            var value = await _apiClient.GetAsync<UpdateContactInfoDto>($"api/ContactInfo/{id}");
            return View(value ?? new UpdateContactInfoDto { ContactInfoId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoDto model)
        {
            var ok = await _apiClient.PutAsync("api/ContactInfo", model);
            if (ok) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var ok = await _apiClient.DeleteAsync($"api/ContactInfo/{id}");
            if (ok) return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
