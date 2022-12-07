namespace BlazorApp.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<string> PlaceOrder();
        Task<List<OrderOverviewResponse>> GetOrders();   
        Task<List<OrderOverviewResponse>> GetAdminOrders();   
        Task<OrderDetailsResponse> GetOrderDetails(int orderId);
        Task<OrderDetailsResponse> GetAdminOrderDetails(int orderId);
    }
}
