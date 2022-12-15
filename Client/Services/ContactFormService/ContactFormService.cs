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

        public event Action OnChange;

        public async Task CreateContact(ContactForm contact)
        {
            var result = await _http.PostAsJsonAsync("api/contact", contact);
            var response = await result.Content.ReadFromJsonAsync<List<ContactForm>>();
            Contacts = response;
        }
      

        public async Task DeleteContact(int id)
        {
            var result = await _http.DeleteAsync($"api/contact/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<ContactForm>>();
            Contacts = response;
        }

        public async Task GetContact()
        {
            var result = await _http.GetFromJsonAsync<List<ContactForm>>("api/Contact");
            
        }
    }
}
