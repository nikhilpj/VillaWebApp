using VillaWebApp.Models;

namespace VillaWebApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Villa>> GetVillasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7266/api/VillaApi");
                response.EnsureSuccessStatusCode();
                var villas = await response.Content.ReadFromJsonAsync<List<Villa>>();
                return villas;
            }
            catch (HttpRequestException ex)
            {
                return new List<Villa>();
            }
            

        }
    }
}
