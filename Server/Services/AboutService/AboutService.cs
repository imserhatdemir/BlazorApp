using BlazorApp.Shared;

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

        private async Task<About> GetAboutById(int id)
        {
            return await _context.Abouts.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<ServiceResponse<List<About>>> GetAdminAbout()
        {
            var about = await _context.Abouts
                 .ToListAsync();
            return new ServiceResponse<List<About>>
            {
                Data = about
            };
        }

        public async Task<ServiceResponse<List<About>>> UpdateAbout(About about)
        {
            var dbCategory = await GetAboutById(about.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<About>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            dbCategory.Title = about.Title;
            dbCategory.ImageUrl = about.ImageUrl;
            dbCategory.Description = about.Description;

            await _context.SaveChangesAsync();
            return await GetAdminAbout();
        }
    }
}
