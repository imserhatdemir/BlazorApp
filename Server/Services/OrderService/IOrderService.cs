namespace BlazorApp.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder(int userId);
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetAdminOrders();
        Task<ServiceResponse<OrderDetailsResponse>> GetOrdersDetails(int orderId);
        Task<ServiceResponse<OrderDetailsResponse>> GetAdminOrdersDetails(int ordersId);
    }
}
