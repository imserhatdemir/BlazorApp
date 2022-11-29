namespace BlazorApp.Server.Services.ContactAddressService
{
    public class ContactAddressService : IContactAddressService
    {
        private readonly DataContext _context;

        public ContactAddressService(DataContext context)
        {
            _context = context;
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
    }
}
