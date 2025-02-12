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
                Console.WriteLine("value of villa", villa);
                var villaJson = new StringContent(JsonSerializer.Serialize(villa), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7266/api/VillaApi", villaJson);
                response.EnsureSuccessStatusCode();
              
                var createdVilla = await response.Content.ReadFromJsonAsync<Villa>();
               
                return createdVilla;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error is the following",ex.Message);
                return new Villa();
            }
           
        }

        public async Task<Villa> GetVilla(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7266/api/VillaApi/{id}");
            response.EnsureSuccessStatusCode();
            var existingVilla = await response.Content.ReadFromJsonAsync<Villa>();
            return existingVilla;
            
        }

       public async Task<bool> UpdateVilla(int id, Villa villa)
        {
            try
            {
                if(villa.Id != id)
                {
                    throw new ArgumentException("Villa ID mismatch");
                }
                var villaJson = new StringContent(JsonSerializer.Serialize(villa), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7266/api/VillaApi/{id}", villaJson);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error in updating", ex.Message);
                return false;
            }
           
        }

        
    }
}
