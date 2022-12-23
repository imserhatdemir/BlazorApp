using Stripe;
using Stripe.Checkout;

namespace BlazorApp.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;


        const string secret = "whsec_f7ff20fd2c03b1ea431b3cb01c73cfd3b5f97da85d79ef88a05ded526237c5b1";

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51M1XMDAG3k3rwVkSEef7G6ci4Cguge5ysbhCvHPbSO6dmtJO8QMy72BXohGOqVX0ocmeEcw6ULK4orXSxUIKxOGQ00OPu6eaoQ";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }
        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProduct()).Data;
            var lineItem = new List<SessionLineItemOptions>();
            products.ForEach(prod => lineItem.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = prod.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = prod.Title,
                        Images = new List<string> { prod.ImageUrl }
                    }
                },
                Quantity = prod.Quantity

            }));


            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries=new List<string> { "TR"}
                },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItem,
                Mode = "payment",
                SuccessUrl = "https://localhost:7148/order-success",
                CancelUrl = "https://localhost:7148/card"

            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest httpRequest)
        {
            var json = await new StreamReader(httpRequest.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                       json,
                        httpRequest.Headers["Stripe-Signature"],
                        secret,
                        throwOnApiVersionMismatch: false
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
}
