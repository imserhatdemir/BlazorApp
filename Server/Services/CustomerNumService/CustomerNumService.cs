namespace BlazorApp.Server.Services.CustomerNumService
{
    public class CustomerNumService : ICustomerNumService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerNumService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        private async Task<CustomerNum> GetSliderById(int id)
        {
            return await _context.CustomerNums.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<ServiceResponse<List<CustomerNum>>> GetAdminNumber()
        {
            var categories = await _context.CustomerNums
                       .Where(c => !c.Deleted)
                       .ToListAsync();
            return new ServiceResponse<List<CustomerNum>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<CustomerNum>>> AddNumber(CustomerNum slider)
        {
            slider.Editing = slider.IsNew = false;
            _context.CustomerNums.Add(slider);
            await _context.SaveChangesAsync();
            return await GetAdminNumber();
        }

        public async Task<ServiceResponse<List<CustomerNum>>> UpdateNumber(CustomerNum slider)
        {
            var dbCategory = await _context.CustomerNums

                         .FirstOrDefaultAsync(p => p.Id == slider.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<CustomerNum>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Number = slider.Number;
            dbCategory.Visible = slider.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminNumber();
        }

        public async Task<ServiceResponse<List<CustomerNum>>> DeleteNumber(int id)
        {
            CustomerNum category = await GetSliderById(id);
            if (category == null)
            {
                return new ServiceResponse<List<CustomerNum>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            _context.CustomerNums.Remove(category);
            await _context.SaveChangesAsync();

            return await GetAdminNumber();
        }

        public async Task<ServiceResponse<CustomerNum>> GetNumber(int id)
        {
            var response = new ServiceResponse<CustomerNum>();
            CustomerNum product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.CustomerNums
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.CustomerNums
                     .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }
    }
}
