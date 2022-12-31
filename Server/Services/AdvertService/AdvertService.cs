namespace BlazorApp.Server.Services.AdvertService
{
    public class AdvertService : IAdvertService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdvertService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<Advert>> CreateAdvert(Advert advert)
        {
           
            _context.Adverts.Add(advert);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Advert> { Data = advert };
        }

        public async Task<ServiceResponse<bool>> DeleteAdvert(int Id)
        {
            var dbProduct = await _context.Adverts.FindAsync(Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found"
                };
            }
            dbProduct.Deleted = true;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Advert>>> GetAdminAdvert()
        {
            var response = new ServiceResponse<List<Advert>>
            {
                Data = await _context.Adverts
                   .Where(p => !p.Deleted)
                   .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Advert>>> GetAdvertAsync()
        {
            var response = new ServiceResponse<List<Advert>>
            {
                Data = await _context.Adverts
                   .Where(p => p.Visible && !p.Deleted)
                   .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Advert>> GetAdvertById(int productId)
        {
            var response = new ServiceResponse<Advert>();
            Advert product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Adverts
                    .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);

            }
            else
            {
                product = await _context.Adverts
                     .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted && p.Visible);

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

        public async Task<ServiceResponse<Advert>> UpdateAdvert(Advert advert)
        {
            var dbProduct = await _context.Adverts
                .FirstOrDefaultAsync(p => p.Id == advert.Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<Advert>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Title = advert.Title;
            dbProduct.Description = advert.Description;
            dbProduct.Image = advert.Image;
            dbProduct.CategoryId = advert.CategoryId;
            dbProduct.Visible = advert.Visible;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Advert> { Data = advert };
        }
    }
}
