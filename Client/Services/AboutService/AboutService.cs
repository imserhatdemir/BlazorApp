using BlazorApp.Client.Pages.Admin;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public List<About> Abouts { get; set; } = new List<About>();

        public event Action OnChange;

        public async Task GetAbout()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<About>>>("api/About");
            if (response != null && response.Data != null)
                Abouts = response.Data;
        }
    }
}
