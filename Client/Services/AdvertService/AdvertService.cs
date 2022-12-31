using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;

namespace BlazorApp.Client.Services.AdvertService
{
    public class AdvertService : IAdvertService
    {
        private readonly HttpClient _http;

        public AdvertService(HttpClient http)
        {
            _http = http;
        }
        public List<Advert> Adverts { get; set; } = new List<Advert>();
        public List<Advert> AdminAdverts { get; set; } = new List<Advert>();
        public string Message { get; set; } = "Loading Advert...";
        public event Action OnChanged;

        public async Task<Advert> CreateAdvert(Advert advert)
        {
            var result = await _http.PostAsJsonAsync("api/advert", advert);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Advert>>()).Data;
        }

        public async Task DeleteAdvert(Advert id)
        {
            var result = await _http.DeleteAsync($"api/advert/{id.Id}");
        }

        public async Task GetAdminAdverts()
        {
            var result = await _http
                         .GetFromJsonAsync<ServiceResponse<List<Advert>>>("api/advert/admin/");
            AdminAdverts = result.Data;
            if (AdminAdverts.Count == 0)
                Message = "No products found.";
        }

        public async Task GetAdvert()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Advert>>>($"api/advert/");
            Adverts = result.Data;
            if (Adverts.Count == 0)
                Message = "No Products found";
        }

        public async Task<ServiceResponse<Advert>> GetAdvertById(int id)
        {

            var result = await _http.GetFromJsonAsync<ServiceResponse<Advert>>($"api/Product/{id}/");
            return result;
        }

        public async Task<Advert> UpdateAdvert(Advert advert)
        {
            var result = await _http.PutAsJsonAsync($"api/advert", advert);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Advert>>()).Data;
        }
    }
}
