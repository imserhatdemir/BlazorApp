namespace BlazorApp.Server.Services.CentreNumberService
{
    public class CentreNumberService : ICentreNumberService
    {
        private readonly DataContext _context;

        public CentreNumberService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CentreNumber>>> GetCentreNumber()
        {
            var about = await _context.CentreNumbers
                .ToListAsync();
            return new ServiceResponse<List<CentreNumber>>
            {
                Data = about
            };
        }
    }
}
