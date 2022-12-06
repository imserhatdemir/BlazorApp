namespace BlazorApp.Server.Services.BankAccountService
{
    public interface IBankAccountService
    {
        Task<ServiceResponse<List<BankAccount>>> GetBankAccount();
        Task<ServiceResponse<List<BankAccount>>> GetAdminBankAccount();
        Task<ServiceResponse<List<BankAccount>>> AddBank(BankAccount bank);
        Task<ServiceResponse<List<BankAccount>>> UpdateBank(BankAccount bank);
        Task<ServiceResponse<List<BankAccount>>> DeleteBank(int id);
    }
}
