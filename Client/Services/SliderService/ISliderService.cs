namespace BlazorApp.Client.Services.SliderService
{
    public interface ISliderService
    {
        event Action OnChange;
        List<Slider> Sliders { get; set; }
        List<Slider> AdminSliders { get; set; }
        Task GetSlider();
        Task GetAdminSlider();
        Task DeleteSlider(int id);
        Task<Slider> UpdateSlider(Slider slider);
        Task AddSlider(Slider slider);
        Slider CreateNewSlider();
        Task<ServiceResponse<Slider>> GetSliders(int id);
        Task<Slider> AddNewSlider(Slider slide);

    }
}
