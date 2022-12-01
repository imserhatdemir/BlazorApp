namespace BlazorApp.Client.Services.ResponsibilityService
{
    public interface IResponsibilityService
    {
        event Action OnChange;
        List<Responsibility> Responsibilities { get; set; }
        Task GetResponsibility();
    }
}
