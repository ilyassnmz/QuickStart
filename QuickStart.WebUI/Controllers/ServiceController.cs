using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Services;
using System.Text;

namespace QuickStart.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        //Api - FARKLI PROGRAMLARIN BİRBİRİYLE KONUŞMASINI SAĞLAR
        //HTTP - İnternetteki cihazların birbiriyle konuşmasını sağlayan bir protokol
        //HTTCLİENT - Apiye http isteklerini göndermemiz için kullanıyoruz.


        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/Service");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServicesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServicesDto model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData=JsonConvert.SerializeObject(model); //göndereceğim veri stringten - json çevirme

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7051/api/Service", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public  async Task<IActionResult> UpdateService(int id)
        {
            var client=_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7051/api/Service/" + id);

            var jsonData=await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);

            return View(values);

        }

        [HttpPost]

        public async Task<IActionResult> UpdateService(UpdateServiceDto model)
        { 
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(model); //text->json

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7051/api/Service", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client=_httpClientFactory.CreateClient();

            var response = await client.DeleteAsync("https://localhost:7051/api/Service?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return BadRequest();

        }


    }
}
