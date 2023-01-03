namespace BlazorApp.Client.Services.FavService
{
    public interface IFavService
    {
        event Action OnChange;
        Task AddToFav(FavItem favItem);
        Task<List<FavProductResponse>> GetFavProduct();
        Task RemoveProductFromFav(int productId);
        Task UpdateQuantity(FavProductResponse product);
        Task StoreFavItems(bool emptyLocalCart);
        Task GetFavItemsCount();
    }
}
