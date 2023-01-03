namespace BlazorApp.Server.Services.FavService
{
    public interface IFavService
    {
        Task<ServiceResponse<List<FavProductResponse>>> GetFavProducts(List<FavItem> favItems);
        Task<ServiceResponse<List<FavProductResponse>>> StoreFavItems(List<FavItem> favItems);
        Task<ServiceResponse<int>> GetFavItemsCount();
        Task<ServiceResponse<List<FavProductResponse>>> GetDbFavProduct(int? userId = null);
        Task<ServiceResponse<bool>> AddToFav(FavItem favItems);
        Task<ServiceResponse<bool>> UpdateQuantity(FavItem favItem);
        Task<ServiceResponse<bool>> RemoveItemFromFav(int productId);
    }
}
