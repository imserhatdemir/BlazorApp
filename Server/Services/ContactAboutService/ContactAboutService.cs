using BlazorApp.Shared;

namespace BlazorApp.Server.Services.ContactAboutService
{
    public class ContactAboutService : IContactAboutService
    {
        private readonly DataContext _context;

        public ContactAboutService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ContactAbout>>> GetContactAbout()
        {
            var about = await _context.ContactAbouts
                 .ToListAsync();
            return new ServiceResponse<List<ContactAbout>>
            {
                Data = about
            };
        }
    }
}
