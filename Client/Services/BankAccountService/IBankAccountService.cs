namespace BlazorApp.Client.Services.BankAccountService
{
    public interface IBankAccountService
    {
        event Action OnChange;
        List<BankAccount> BankAccounts { get; set; }
        List<BankAccount> AdminBankAccounts { get; set; }
        Task GetBankAccount();
        Task GetAdminBankAccount();
        Task DeleteBank(int bankId);
        Task UpdateBank(BankAccount bank);
        Task AddBank(BankAccount bank);
        BankAccount CreateNewBank();
    }
}
