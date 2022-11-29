namespace BlazorApp.Server.Services.ResponsibilityService
{
    public class ResponsibilityService : IResponsibilityService
    {
        private readonly DataContext _context;

        public ResponsibilityService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Responsibility>>> GetResponsibility()
        {
            var about = await _context.Responsibilities
                 .ToListAsync();
            return new ServiceResponse<List<Responsibility>>
            {
                Data = about
            };
        }
    }
}
