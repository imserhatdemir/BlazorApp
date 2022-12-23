namespace BlazorApp.Server.Services.SendMailService
{
    public class SendMailService : ISendMailService
    {
        private readonly DataContext _context;

        public SendMailService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<SendMail>> AddMail(SendMail send)
        {
            _context.Sends.Add(send);
            await _context.SaveChangesAsync();
            return new ServiceResponse<SendMail> { Data = send };
        }


        public async Task<ServiceResponse<SendMail>> DeleteMail(int id)
        {
            var contact = _context.Sends.FirstOrDefault(c => c.Id == id);
            _context.Sends.Remove(contact);
            await _context.SaveChangesAsync();
            return new ServiceResponse<SendMail>();
        }

        public async Task<ServiceResponse<List<SendMail>>> GetMail()
        {
            var response = new ServiceResponse<List<SendMail>>
            {
                Data = await _context.Sends
              .ToListAsync()
            };
            return response;
        }


        private async Task<SendMail> GetMailById(int id)
        {
            return await _context.Sends.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
