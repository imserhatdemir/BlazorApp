namespace BlazorApp.Server.Services.ContactAddressService
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactAddressService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        private async Task<ContactAddress> GetSliderById(int id)
        {
            return await _context.ContactAddresses.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<ServiceResponse<List<ContactAddress>>> AddAddress(ContactAddress slider)
        {
            slider.Editing = slider.IsNew = false;
            _context.ContactAddresses.Add(slider);
            await _context.SaveChangesAsync();
            return await GetAdminAddress();
        }

        public async Task<ServiceResponse<ContactAddress>> AddCAddressNew(ContactAddress slider)
        {
            _context.ContactAddresses.Add(slider);
            await _context.SaveChangesAsync();
            return new ServiceResponse<ContactAddress> { Data = slider };
        }

        public async Task<ServiceResponse<List<ContactAddress>>> DeleteAddress(int id)
        {
            ContactAddress category = await GetSliderById(id);
            if (category == null)
            {
                return new ServiceResponse<List<ContactAddress>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            _context.ContactAddresses.Remove(category);
            await _context.SaveChangesAsync();

            return await GetAdminAddress();
        }

        public async Task<ServiceResponse<ContactAddress>> GetAddress(int id)
        {
            var response = new ServiceResponse<ContactAddress>();
            ContactAddress product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.ContactAddresses
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.ContactAddresses
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

        public async Task<ServiceResponse<List<ContactAddress>>> GetAdminAddress()
        {
            var categories = await _context.ContactAddresses
             .Where(c => !c.Deleted)
             .ToListAsync();
            return new ServiceResponse<List<ContactAddress>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<ContactAddress>>> GetContactAddress()
        {
            var about = await _context.ContactAddresses
                .ToListAsync();
            return new ServiceResponse<List<ContactAddress>>
            {
                Data = about
            };
        }

        public async Task<ServiceResponse<List<ContactAddress>>> UpdateAddress(ContactAddress slider)
        {
            var dbCategory = await _context.ContactAddresses

                          .FirstOrDefaultAsync(p => p.Id == slider.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<ContactAddress>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Address = slider.Address;
            dbCategory.Location = slider.Location;
            dbCategory.Mail = slider.Mail;
            dbCategory.Number = slider.Number;
            dbCategory.Title = slider.Title;
            dbCategory.Visible = slider.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminAddress();
        }
    }
}
