using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.ContactAddressService
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly HttpClient _http;

        public ContactAddressService(HttpClient http)
        {
            _http = http;
        }
        public List<ContactAddress> ContactAddresses { get; set; } = new List<ContactAddress>();
        public List<ContactAddress> AdminContactAddresses { get; set; } = new List<ContactAddress>();

        public event Action OnChange;

        public async Task AddAddress(ContactAddress slider)
        {
            var response = await _http.PostAsJsonAsync("api/contactaddress/admin", slider);
            AdminContactAddresses = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ContactAddress>>>()).Data;
            await GetContactAddress();
            OnChange.Invoke();
        }

        public async Task<ContactAddress> AddNewAddress(ContactAddress slide)
        {
            var result = await _http.PostAsJsonAsync("api/contactaddress", slide);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<ContactAddress>>()).Data;
        }

        public ContactAddress CreateAddress()
        {
            var newCategory = new ContactAddress { IsNew = true, Editing = true };
            AdminContactAddresses.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteAddress(int id)
        {
            var result = await _http.DeleteAsync($"api/contactaddress/admin/{id}");
        }

        public async Task<ServiceResponse<ContactAddress>> GetAddressID(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<ContactAddress>>($"api/contactaddress/{id}/");
            return result;
        }

        public async Task GetAdminContactAddress()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ContactAddress>>>("api/contactaddress/admin");
            if (response != null && response.Data != null)
                AdminContactAddresses = response.Data;
        }

        public async Task GetContactAddress()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ContactAddress>>>("api/ContactAddress");
            if (response != null && response.Data != null)
                ContactAddresses = response.Data;
        }

        public async Task UpdateAddress(ContactAddress slider)
        {
            var response = await _http.PutAsJsonAsync("api/contactaddress/admin/", slider);
            AdminContactAddresses = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ContactAddress>>>()).Data;
            await GetAdminContactAddress();
        }
    }
}
