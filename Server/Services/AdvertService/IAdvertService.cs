namespace BlazorApp.Server.Services.AdvertService
{
    public interface IAdvertService
    {
        Task<ServiceResponse<List<Advert>>> GetAdvertAsync();
        Task<ServiceResponse<Advert>> GetAdvertById(int productId);
        Task<ServiceResponse<List<Advert>>> GetAdminAdvert();
        Task<ServiceResponse<Advert>> CreateAdvert(Advert advert);
        Task<ServiceResponse<Advert>> UpdateAdvert(Advert advert);
        Task<ServiceResponse<bool>> DeleteAdvert(int Id);
    }
}
