namespace BlazorApp.Client.Services.AdvertService
{
    public interface IAdvertService
    {
        event Action OnChanged;
        List<Advert> Adverts { get; set; }
        List<Advert> AdminAdverts { get; set; }
        string Message { get; set; }
        Task<ServiceResponse<Advert>> GetAdvertById(int id);
        Task GetAdminAdverts();
        Task GetAdvert();
        Task<Advert> CreateAdvert(Advert advert);
        Task<Advert> UpdateAdvert(Advert advert);
        Task DeleteAdvert(Advert id);
    }
}
