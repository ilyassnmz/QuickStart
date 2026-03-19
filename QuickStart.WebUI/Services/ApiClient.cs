using Newtonsoft.Json;
using System.Text;

namespace QuickStart.WebUI.Services
{
    public class ApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        private string BaseUrl =>
            _configuration["ApiSettings:BaseUrl"]?.TrimEnd('/')
            ?? throw new InvalidOperationException("ApiSettings:BaseUrl is not configured.");

        public async Task<T?> GetAsync<T>(string path)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{BaseUrl}/{path.TrimStart('/')}");
            if (!response.IsSuccessStatusCode) return default;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<bool> PostAsync<T>(string path, T body)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{BaseUrl}/{path.TrimStart('/')}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync<T>(string path, T body)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{BaseUrl}/{path.TrimStart('/')}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string path)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{BaseUrl}/{path.TrimStart('/')}");
            return response.IsSuccessStatusCode;
        }
    }
}
