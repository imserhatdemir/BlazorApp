namespace BlazorApp.Server.Services.FaqService
{
    public class FaqService : IFaqService
    {
        private readonly DataContext _context;

        public FaqService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Faq>>> GetFaq()
        {
            var about = await _context.Faqs
                .ToListAsync();
            return new ServiceResponse<List<Faq>>
            {
                Data = about
            };
        }
    }
}
