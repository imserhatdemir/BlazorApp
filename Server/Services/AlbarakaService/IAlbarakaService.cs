namespace BlazorApp.Server.Services.AlbarakaService
{
    public interface IAlbarakaService
    {
        Task<HttpResponseMessage> ProcessPayment(AlbarakaRequest albarakaRequest);
    }
}
