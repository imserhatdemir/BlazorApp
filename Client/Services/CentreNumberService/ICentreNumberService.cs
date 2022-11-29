namespace BlazorApp.Client.Services.CentreNumberService
{
    public interface ICentreNumberService
    {
        List<CentreNumber> CentreNumbers { get; set; }
        Task GetCentreNumber();
    }
}
