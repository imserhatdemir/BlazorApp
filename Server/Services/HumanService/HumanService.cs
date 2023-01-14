namespace BlazorApp.Server.Services.HumanService
{
    public class HumanService : IHumanService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HumanService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<ServiceResponse<HumanResources>> GetFaqById(int id)
        {
            var response = new ServiceResponse<HumanResources>();
            HumanResources product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Humans
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.Humans
                     .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
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
