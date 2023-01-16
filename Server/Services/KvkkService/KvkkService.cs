namespace BlazorApp.Server.Services.KvkkService
{
    public class KvkkService : IKvkkService
    {
        private readonly DataContext _context;

        public KvkkService(DataContext context)
        {
            _context = context;
        }
        private async Task<Kvkk> GetBrandById(int id)
        {
            return await _context.Kvkks.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<ServiceResponse<List<Kvkk>>> AddKvkk(Kvkk brand)
        {
            brand.Editing = brand.IsNew = false;
            _context.Kvkks.Add(brand);
            await _context.SaveChangesAsync();
            return await GetAdminKvkk();
        }

        public async Task<ServiceResponse<List<Kvkk>>> GetAdminKvkk()
        {
            var categories = await _context.Kvkks
                           .Where(c => !c.Deleted)
                           .ToListAsync();
            return new ServiceResponse<List<Kvkk>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Kvkk>>> GetKvkk()
        {
            var brand = await _context.Kvkks.Where(c => !c.Deleted).ToListAsync();
            return new ServiceResponse<List<Kvkk>>
            {
                Data = brand
            };
        }

        public async Task<ServiceResponse<List<Kvkk>>> UpdateKvkk(Kvkk brand)
        {
            var dbCategory = await GetBrandById(brand.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Kvkk>>
                {
                    Success = false,
                    Message = "Brand not found"
                };
            }

            dbCategory.Details = brand.Details;
            dbCategory.Name = brand.Name;
            dbCategory.Visible = brand.Visible;

            

            await _context.SaveChangesAsync();
            return await GetAdminKvkk();
        }
    }
}
