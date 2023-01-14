namespace BlazorApp.Client.Services.ContactAboutService
{
    public interface IContactAboutService
    {
        event Action OnChange;
        List<ContactAbout> ContactAbouts { get; set; }
        List<ContactAbout> AdminContactAbouts { get; set; }
        Task GetContactAbout();
        Task GetAdminContactAbout();
        Task DeleteContAbout(int id);
        Task UpdateSlider(ContactAbout slider);
        Task AddSlider(ContactAbout slider);
        ContactAbout CreateNewSlider();
        Task<ServiceResponse<ContactAbout>> GetSliders(int id);
        Task<ContactAbout> AddNewSlider(ContactAbout slide);
    }
}
