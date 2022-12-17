using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Services.ContactFormService
{
    public class ContactFormService : IContactFormService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ContactFormService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<ContactForm> Contacts { get; set; } = new List<ContactForm>();
        public string Message { get; set; } = "loading";

        public event Action OnChange;


        public async Task GetContactAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ContactForm>>>("api/Contact");
            if (response != null && response.Data != null)
                Contacts = response.Data;
        }

        public async Task<ContactForm> CreateContact(ContactForm product)
        {
            var result = await _http.PostAsJsonAsync("api/contact", product);
            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<ContactForm>>()).Data;
            return newProduct;
        }

        public async Task DeleteContact(int productId)
        {
            var result = await _http.DeleteAsync($"api/contact/{productId}");
            await GetContactAsync();
        }
    }
}
