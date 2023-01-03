using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavController : ControllerBase
    {
        private readonly IFavService _favService;

        public FavController(IFavService favService)
        {
           _favService = favService;
        }


        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponse<List<FavProductResponse>>>> GetFavProduct(List<FavItem> favItems)
        {
            var result = await _favService.GetFavProducts(favItems);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FavProductResponse>>>> StoreCartItems(List<FavItem> favItems)
        {

            var result = await _favService.StoreFavItems(favItems);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetFavItemsCount()
        {
            return await _favService.GetFavItemsCount();
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FavProductResponse>>>> GetDbFavProduct()
        {
            var result = await _favService.GetDbFavProduct();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(FavItem favItem)
        {

            var result = await _favService.AddToFav(favItem);
            return Ok(result);
        }

        

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId)
        {

            var result = await _favService.RemoveItemFromFav(productId);
            return Ok(result);
        }


        [HttpPut("update-quantity")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(FavItem cartItems)
        {

            var result = await _favService.UpdateQuantity(cartItems);
            return Ok(result);
        }
    }
}
