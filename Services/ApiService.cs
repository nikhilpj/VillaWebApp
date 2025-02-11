using System.Text;
using System.Text.Json;
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

        public async Task<Villa> PostVillasAsync(Villa villa)
        {
            try
            {
                var villaJson = new StringContent(JsonSerializer.Serialize(villa), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7266/api/VillaApi", villaJson);
                response.EnsureSuccessStatusCode();
                var createdVilla = await response.Content.ReadFromJsonAsync<Villa>();
                return createdVilla;
            }
            catch (HttpRequestException ex)
            {
                return new Villa();
            }
           
        }

        
    }
}
