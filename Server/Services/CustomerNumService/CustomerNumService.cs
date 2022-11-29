namespace BlazorApp.Server.Services.CustomerNumService
{
    public class CustomerNumService : ICustomerNumService
    {
        private readonly DataContext _context;

        public CustomerNumService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CustomerNum>>> GetNumber()
        {
            var cnum = await _context.CustomerNums
                  .ToListAsync();
            return new ServiceResponse<List<CustomerNum>>
            {
                Data = cnum
            };
        }
    }
}
