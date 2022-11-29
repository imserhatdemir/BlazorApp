namespace BlazorApp.Client.Services.BankAccountService
{
    public interface IBankAccountService
    {
        List<BankAccount> BankAccounts { get; set; }
        Task GetBankAccount();
    }
}
