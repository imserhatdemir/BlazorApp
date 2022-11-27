namespace BlazorApp.Server.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly DataContext _context;

        public AboutService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<About>>> GetAbout()
        {
            var about = await _context.Abouts
                 .ToListAsync();
            return new ServiceResponse<List<About>>
            {
                Data = about
            };
        }
    }
}
