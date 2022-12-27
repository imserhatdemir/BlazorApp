namespace BlazorApp.Server.Services.ShipmentService
{
    public interface IShipmentService
    {
        Task<ServiceResponse<List<Shipment>>> GetAdminShipment();
        Task<ServiceResponse<Shipment>> CreateShipment(Shipment ship);
        Task<ServiceResponse<List<Shipment>>> UpdateShipment(Shipment ship);
        Task<ServiceResponse<bool>> DeleteShipment(int Id);
        Task<ServiceResponse<ShipmentSearch>> SearchShipment(string searchText, int page);
    }
}
