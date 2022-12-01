namespace BlazorApp.Client.Services.BankAccountService
{
    public interface IBankAccountService
    {
        event Action OnChange;
        List<BankAccount> BankAccounts { get; set; }
        Task GetBankAccount();
    }
}
