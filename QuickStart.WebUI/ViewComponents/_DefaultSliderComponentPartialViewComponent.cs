using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Sliders;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultSliderComponentPartialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7121/api/Slider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultSliderDto>());
        }
    }
}