namespace BlazorApp.Client.Services.AlbarakaPosService
{
    public interface IAlbarakaPosService
    {
        Task<HttpResponseMessage> ProcessPayment(decimal amount, string cardNumber, string cardExpiry, string cardCVV);
    }
}
