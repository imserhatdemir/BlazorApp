namespace BlazorApp.Client.Services.ContactAboutService
{
    public class ContactAboutService : IContactAboutService
    {
        private readonly HttpClient _httpClient;

        public ContactAboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<ContactAbout> ContactAbouts { get; set; } = new List<ContactAbout>();

        public event Action OnChange;

        public async Task GetContactAbout()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<ContactAbout>>>("api/ContactAbout");
            if (response != null && response.Data != null)
                ContactAbouts = response.Data;
        }
    }
}
