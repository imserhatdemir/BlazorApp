namespace BlazorApp.Client.Services.BankAccountService
{
    public class BankAccountService : IBankAccountService
    {
        private readonly HttpClient _httpClient;

        public BankAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

        public event Action OnChange;

        public async Task GetBankAccount()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<BankAccount>>>("api/BankAccount");
            if (response != null && response.Data != null)
                BankAccounts = response.Data;
        }
    }
}
