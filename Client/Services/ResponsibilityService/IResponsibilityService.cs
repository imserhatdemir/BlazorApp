namespace BlazorApp.Client.Services.ResponsibilityService
{
    public interface IResponsibilityService
    {
        List<Responsibility> Responsibilities { get; set; }
        Task GetResponsibility();
    }
}
