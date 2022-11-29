namespace BlazorApp.Server.Services.BankAccountService
{
    public interface IBankAccountService
    {
        Task<ServiceResponse<List<BankAccount>>> GetBankAccount();
    }
}
