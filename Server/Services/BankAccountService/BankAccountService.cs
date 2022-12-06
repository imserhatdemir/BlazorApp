using BlazorApp.Shared;

namespace BlazorApp.Server.Services.BankAccountService
{
    public class BankAccountService : IBankAccountService
    {
        private readonly DataContext _context;

        public BankAccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<BankAccount>>> AddBank(BankAccount bank)
        {
            bank.Editing = bank.IsNew = false;
            _context.BankAccounts.Add(bank);
            await _context.SaveChangesAsync();
            return await GetAdminBankAccount();
        }

        private async Task<BankAccount> GetBankById(int id)
        {
            return await _context.BankAccounts.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<ServiceResponse<List<BankAccount>>> DeleteBank(int id)
        {
            BankAccount category = await GetBankById(id);
            if (category == null)
            {
                return new ServiceResponse<List<BankAccount>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            category.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetAdminBankAccount();
        }

        public async Task<ServiceResponse<List<BankAccount>>> GetAdminBankAccount()
        {
            var categories = await _context.BankAccounts
               .Where(c => !c.Deleted)
               .ToListAsync();
            return new ServiceResponse<List<BankAccount>>
            {
                Data = categories
            };
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

        public async Task<ServiceResponse<List<BankAccount>>> UpdateBank(BankAccount bank)
        {
            var dbCategory = await GetBankById(bank.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<BankAccount>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            dbCategory.Address = bank.Address;
            dbCategory.Iban = bank.Iban;
            dbCategory.ImageUrl = bank.ImageUrl;
            dbCategory.Visible = bank.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminBankAccount();
        }
    }
}
