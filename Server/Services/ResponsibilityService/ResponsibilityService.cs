namespace BlazorApp.Server.Services.ResponsibilityService
{
    public class ResponsibilityService : IResponsibilityService
    {
        private readonly DataContext _context;

        public ResponsibilityService(DataContext context)
        {
            _context = context;
        }

        private async Task<Responsibility> GetRespById(int id)
        {
            return await _context.Responsibilities.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<ServiceResponse<List<Responsibility>>> AddResp(Responsibility responsibility)
        {
            responsibility.Editing = responsibility.IsNew = false;
            _context.Responsibilities.Add(responsibility);
            await _context.SaveChangesAsync();
            return await GetAdminResp();
        }

        public async Task<ServiceResponse<List<Responsibility>>> GetAdminResp()
        {
            var about = await _context.Responsibilities.Where(c=>!c.Deleted)
                 .ToListAsync();
            return new ServiceResponse<List<Responsibility>>
            {
                Data = about
            };
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

        public async Task<ServiceResponse<List<Responsibility>>> UpdateResp(Responsibility responsibility)
        {
            var dbCategory = await GetRespById(responsibility.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Responsibility>>
                {
                    Success = false,
                    Message = "Responsibility not found"
                };
            }
            dbCategory.Title = responsibility.Title;
            dbCategory.ImageUrl = responsibility.ImageUrl;
            dbCategory.Details = responsibility.Details;
            dbCategory.Visible = responsibility.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminResp();
        }
    }
}
