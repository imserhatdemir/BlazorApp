using Stripe.Checkout;

namespace BlazorApp.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest httpRequest);
    }
}
