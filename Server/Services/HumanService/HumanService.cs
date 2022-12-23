namespace BlazorApp.Server.Services.HumanService
{
    public class HumanService : IHumanService
    {
        private readonly DataContext _context;

        public HumanService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<HumanResources>>> AddHuman(HumanResources human)
        {
            human.Editing = human.IsNew = false;
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();
            return await GetAdminHuman();
        }

        public async Task<ServiceResponse<List<HumanResources>>> GetAdminHuman()
        {
            var about = await _context.Humans.Where(c => !c.Deleted)
                 .ToListAsync();
            return new ServiceResponse<List<HumanResources>>
            {
                Data = about
            };
        }

        public async Task<ServiceResponse<List<HumanResources>>> GetHuman()
        {
            var human = await _context.Humans
                 .ToListAsync();
            return new ServiceResponse<List<HumanResources>>
            {
                Data = human
            };
        }

        public async Task<ServiceResponse<List<HumanResources>>> UpdateHuman(HumanResources human)
        {
            var dbCategory = await GetHumanById(human.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<HumanResources>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Title = human.Title;
            dbCategory.ImageUrl = human.ImageUrl;
            dbCategory.Details = human.Details;
            dbCategory.Visible = human.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminHuman();
        }


        private async Task<HumanResources> GetHumanById(int id)
        {
            return await _context.Humans.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
