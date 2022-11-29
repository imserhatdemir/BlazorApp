namespace BlazorApp.Server.Services.BankAccountService
{
    public class BankAccountService : IBankAccountService
    {
        private readonly DataContext _context;

        public BankAccountService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<BankAccount>>> GetBankAccount()
        {
            var about = await _context.BankAccounts
                 .ToListAsync();
            return new ServiceResponse<List<BankAccount>>
            {
                Data = about
            };
        }
    }
}
