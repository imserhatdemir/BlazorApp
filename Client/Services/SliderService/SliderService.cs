using BlazorApp.Client.Pages;
using BlazorApp.Shared;
using System.Net.Http;

namespace BlazorApp.Client.Services.SliderService
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _http;

        public SliderService(HttpClient http)
        {
            _http = http;
        }
        public List<Slider> Sliders { get; set; } = new List<Slider>();
        public List<Slider> AdminSliders { get; set; } = new List<Slider>();

        public event Action OnChange;

        public async Task<Slider> AddNewSlider(Slider slide)
        {
            var result = await _http.PostAsJsonAsync("api/slider", slide);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Slider>>()).Data;
        }

        public async Task AddSlider(Slider slider)
        {
            var response = await _http.PostAsJsonAsync("api/Slider/admin", slider);
            AdminSliders = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Slider>>>()).Data;
            await GetSlider();
            OnChange.Invoke();
        }

        public Slider CreateNewSlider()
        {
            var newCategory = new Slider { IsNew = true, Editing = true };
            AdminSliders.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteSlider(int id)
        {
            var result = await _http.DeleteAsync($"api/slider/admin/{id}");
            
        }

        public async Task GetAdminSlider()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Slider>>>("api/Slider/admin");
            if (response != null && response.Data != null)
                AdminSliders = response.Data;
        }

        public async Task GetSlider()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Slider>>>("api/Slider");
            if (response != null && response.Data != null)
                Sliders = response.Data;
        }

        public async Task<ServiceResponse<Slider>> GetSliders(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Slider>>($"api/Slider/{id}/");
            return result; 
        }

        public async Task UpdateSlider(Slider slider)
        {

            var response = await _http.PutAsJsonAsync("api/Slider/admin/", slider);
            AdminSliders = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Slider>>>()).Data;
            await GetAdminSlider();
        }
    }
}
