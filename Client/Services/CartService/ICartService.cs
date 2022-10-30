namespace BlazorApp.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItem();
        Task <List<CartProductResponse>> GetCartProduct();
        Task RemoveProductFromCart(int productId,int productTypeId);
        Task UpdateQuantity(CartProductResponse product);
    }
}
