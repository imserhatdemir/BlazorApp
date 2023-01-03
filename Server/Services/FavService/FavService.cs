using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;

namespace BlazorApp.Server.Services.FavService
{
    public class FavService : IFavService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public FavService(DataContext context, IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }


        public async Task<ServiceResponse<bool>> AddToFav(FavItem favItems)
        {
            favItems.UserId = _authService.GetUserId();

            var sameItem = await _context.FavItems
            .FirstOrDefaultAsync(ci => ci.ProductId == favItems.ProductId && ci.UserId == favItems.UserId);
            if (sameItem == null)
            {
                _context.FavItems.Add(favItems);
            }
            else
            {
                sameItem.Quantity = favItems.Quantity;
            }
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }




        public async Task<ServiceResponse<List<FavProductResponse>>> GetDbFavProduct(int? userId = null)
        {
            if (userId == null)
                userId = _authService.GetUserId();

            return await GetFavProducts(await _context.FavItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync());
        }




        public async Task<ServiceResponse<int>> GetFavItemsCount()
        {
            var count = (await _context.FavItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int> { Data = count };
        }




        public async Task<ServiceResponse<List<FavProductResponse>>> GetFavProducts(List<FavItem> favItems)
        {
            var result = new ServiceResponse<List<FavProductResponse>>
            {
                Data = new List<FavProductResponse>()
            };

            foreach (var item in favItems)
            {
                var product = await _context.Products
                    .Where(p => p.ID == item.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    continue;
                }
                var productVariant = await _context.ProductVariants
                    .Where(v => v.ProductId == item.ProductId )
                    .Include(v => v.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartProduct = new FavProductResponse
                {
                    ProductId = product.ID,
                    Title = product.Title,
                    ImageUrl = product.ImageURL,
                    Price = productVariant.Price,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }
            return result;
        }




        public async Task<ServiceResponse<bool>> RemoveItemFromFav(int productId)
        {
            var cItem = await _context.FavItems
                       .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.UserId == _authService.GetUserId());

            if (cItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist"
                };
            }

            _context.FavItems.Remove(cItem);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Data = true
            };
        }





        public async Task<ServiceResponse<List<FavProductResponse>>> StoreFavItems(List<FavItem> favItems)
        {
            favItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _context.FavItems.AddRange(favItems);
            await _context.SaveChangesAsync();

            return await GetDbFavProduct();
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(FavItem favItem)
        {
            var cItem = await _context.FavItems
                            .FirstOrDefaultAsync(ci => ci.ProductId == favItem.ProductId && ci.UserId == _authService.GetUserId());

            if (cItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist"
                };
            }

            cItem.Quantity = favItem.Quantity;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
