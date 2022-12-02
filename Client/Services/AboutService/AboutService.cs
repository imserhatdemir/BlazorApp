using BlazorApp.Shared;

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
        public List<About> AdminAbouts { get; set; } = new List<About>();

        public event Action OnChange;

        public async Task AddAbout(About about)
        {
            var response = await _httpClient.PostAsJsonAsync("api/About/admin", about);
            AdminAbouts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<About>>>()).Data;
            await GetAbout();
            OnChange.Invoke();
        }

        public About CreateNewAbout()
        {
            var newCategory = new About { IsNew = true, Editing = true };
            AdminAbouts.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task GetAbout()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<About>>>("api/About");
            if (response != null && response.Data != null)
                Abouts = response.Data;
        }

        public async Task GetAdminAbout()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<About>>>("api/About/admin");
            if (response != null && response.Data != null)
                AdminAbouts = response.Data;
        }

        public async Task UpdateAbout(About about)
        {
            var response = await _httpClient.PutAsJsonAsync("api/About/admin", about);
            AdminAbouts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<About>>>()).Data;
            await GetAdminAbout();
            OnChange.Invoke();
        }
    }
}
