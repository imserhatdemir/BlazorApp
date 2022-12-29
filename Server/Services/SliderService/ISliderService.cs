namespace BlazorApp.Server.Services.SliderService
{
    public interface ISliderService
    {
        Task<ServiceResponse<List<Slider>>> GetSlide();
        Task<ServiceResponse<List<Slider>>> GetAdminSlide();
        Task<ServiceResponse<List<Slider>>> AddSlide(Slider slider);
        Task<ServiceResponse<List<Slider>>> UpdateSlide(Slider slider);
        Task<ServiceResponse<List<Slider>>> DeleteSlide(int id);
    }
}
