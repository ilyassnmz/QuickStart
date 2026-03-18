using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Notification;

namespace QuickStart.WebUI.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminLayoutNavbarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/Notification/GetNotificationListwithNotificationType");

            if(response.IsSuccessStatusCode) 
            { 
               var jsonData=await response.Content.ReadAsStringAsync();
               var values = JsonConvert.DeserializeObject<List<ResultNotificaitonWithNotificationTypeDto>>(jsonData);
               return View(values);

              }
            return View();
        }
    }
}
