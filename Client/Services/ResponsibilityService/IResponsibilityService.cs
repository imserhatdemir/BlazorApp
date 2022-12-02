namespace BlazorApp.Client.Services.ResponsibilityService
{
    public interface IResponsibilityService
    {
        event Action OnChange;
        List<Responsibility> Responsibilities { get; set; }
        List<Responsibility> AdminResponsibilities { get; set; }
        Task GetResponsibility();
        Task GetAdminResponsibility();
        Task AddResponsibility(Responsibility responsibility);
        Task UpdateResponsibility(Responsibility responsibility);
        Responsibility CreateNewResp();
    }
}
