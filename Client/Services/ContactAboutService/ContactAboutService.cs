using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.ContactAboutService
{
    public class ContactAboutService : IContactAboutService
    {
        private readonly HttpClient _http;

        public ContactAboutService(HttpClient http)
        {
            _http = http;
        }
        public List<ContactAbout> ContactAbouts { get; set; } = new List<ContactAbout>();
        public List<ContactAbout> AdminContactAbouts { get; set; } = new List<ContactAbout>();

        public event Action OnChange;

        public async Task<ContactAbout> AddNewSlider(ContactAbout slide)
        {
            var result = await _http.PostAsJsonAsync("api/contactabout", slide);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<ContactAbout>>()).Data;
        }

        public async Task AddSlider(ContactAbout slider)
        {
            var response = await _http.PostAsJsonAsync("api/contactabout/admin", slider);
            AdminContactAbouts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ContactAbout>>>()).Data;
            await GetContactAbout();
            OnChange.Invoke();
        }

        public ContactAbout CreateNewSlider()
        {
            var newCategory = new ContactAbout { IsNew = true, Editing = true };
            AdminContactAbouts.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteContAbout(int id)
        {
            var result = await _http.DeleteAsync($"api/contactabout/admin/{id}");
        }

        public async Task GetAdminContactAbout()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ContactAbout>>>("api/contactabout/admin");
            if (response != null && response.Data != null)
                AdminContactAbouts = response.Data;
        }

        public async Task GetContactAbout()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ContactAbout>>>("api/ContactAbout");
            if (response != null && response.Data != null)
                ContactAbouts = response.Data;
        }

        public async Task<ServiceResponse<ContactAbout>> GetSliders(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<ContactAbout>>($"api/contactabout/{id}/");
            return result;
        }

        public async Task UpdateSlider(ContactAbout slider)
        {
            var response = await _http.PutAsJsonAsync("api/contactabout/admin/", slider);
            AdminContactAbouts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ContactAbout>>>()).Data;
            await GetAdminContactAbout();
        }
    }
}
