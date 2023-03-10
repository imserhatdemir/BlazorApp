using BlazorApp.Shared;
using Stripe;
using System.Security.Claims;

namespace BlazorApp.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public CartService(DataContext context, IHttpContextAccessor httpContextAccessor,IAuthService authService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }




        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>> 
            { 
                Data=new List<CartProductResponse>()
            };

            foreach(var item in cartItems)
            {
                var product = await _context.Products
                    .Where(p => p.ID == item.ProductId).Include(v => v.Images)
                    .FirstOrDefaultAsync();


                if (product == null)
                {
                    continue;
                }
                var productVariant = await _context.ProductVariants
                    .Where(v => v.ProductId == item.ProductId && v.ProductTypeId == item.ProductTypeId)
                    .Include(v => v.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponse 
                {
                    ProductId= product.ID,
                    Title = product.Title,
                    ImageUrl = product.ImageURL,
                    Price=productVariant.Price,
                    ProductType= productVariant.ProductType.Name,
                    ProductTypeId= productVariant.ProductTypeId,
                    Quantity=item.Quantity,
                    Images = product.Images
                };

                result.Data.Add(cartProduct);
            }
            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem=>cartItem.UserId = _authService.GetUserId());
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetDbCartProduct();

        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int> { Data = count };

        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProduct(int? userId=null)
        {
            if (userId == null)
                userId = _authService.GetUserId();

            return await GetCartProducts(await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId && ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == cartItem.UserId);
            if(sameItem == null)
            {
                _context.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity = cartItem.Quantity;
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var cItem= await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId && ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == _authService.GetUserId());

            if (cItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist"
                };
            }

            cItem.Quantity = cartItem.Quantity;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data= true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var cItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.ProductTypeId == productTypeId && ci.UserId == _authService.GetUserId());

            if (cItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist"
                };
            }

            _context.CartItems.Remove(cItem);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Data = true
            };
        }
    }
}
