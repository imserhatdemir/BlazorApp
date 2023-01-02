using BlazorApp.Shared;
using static System.Net.WebRequestMethods;

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
        public List<BankAccount> AdminBankAccounts { get; set; } = new List<BankAccount>();

        public event Action OnChange;

        public async Task AddBank(BankAccount bank)
        {
            var response = await _httpClient.PostAsJsonAsync("api/BankAccount/admin", bank);
            AdminBankAccounts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BankAccount>>>()).Data;
            await GetBankAccount();
            OnChange.Invoke();
        }

        public BankAccount CreateNewBank()
        {
            var newCategory = new BankAccount { IsNew = true, Editing = true };
            AdminBankAccounts.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteBank(int bankId)
        {
            var response = await _httpClient.DeleteAsync($"api/BankAccount/admin/{bankId}");
            AdminBankAccounts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BankAccount>>>()).Data;
            await GetBankAccount();
            OnChange.Invoke();
        }

        public async Task GetAdminBankAccount()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<BankAccount>>>("api/BankAccount/admin/");
                AdminBankAccounts = response.Data;
        }

        public async Task GetBankAccount()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<BankAccount>>>("/api/BankAccount");
            if (response != null && response.Data != null)
                BankAccounts = response.Data;
        }

        public async Task UpdateBank(BankAccount bank)
        {
            var response = await _httpClient.PutAsJsonAsync("api/BankAccount/admin", bank);
            AdminBankAccounts = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BankAccount>>>()).Data;
            await GetBankAccount();
            OnChange.Invoke();
        }
    }
}
