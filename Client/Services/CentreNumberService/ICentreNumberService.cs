namespace BlazorApp.Client.Services.CentreNumberService
{
    public interface ICentreNumberService
    {
        event Action OnChange;
        List<CentreNumber> CentreNumbers { get; set; }
        Task GetCentreNumber();
    }
}
