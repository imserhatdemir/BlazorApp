namespace BlazorApp.Server.Services.AlbarakaService
{
    public interface IAlbarakaService
    {
        Task<string> ProcessPaymentAsync(string storeId, string apiKey, string orderId, decimal amount, string currency, string paymentType);
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest httpRequest);
    }
}
