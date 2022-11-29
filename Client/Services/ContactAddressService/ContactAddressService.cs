namespace BlazorApp.Client.Services.ContactAddressService
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly HttpClient _httpClient;

        public ContactAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<ContactAddress> ContactAddresses { get; set; } = new List<ContactAddress>();

        public async Task GetContactAddress()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<ContactAddress>>>("api/ContactAddress");
            if (response != null && response.Data != null)
                ContactAddresses = response.Data;
        }
    }
}
