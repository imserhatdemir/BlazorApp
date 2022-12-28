namespace BlazorApp.Server.Services.ShipmentService
{
    public interface IShipmentService
    {
        Task<ServiceResponse<List<Shipment>>> GetAdminShipment();
        Task<ServiceResponse<Shipment>> CreateShipment(Shipment ship);
        Task<ServiceResponse<Shipment>> UpdateShipment(Shipment ship);
        Task<ServiceResponse<List<Shipment>>> DeleteShip(int id);
        Task<ServiceResponse<ShipmentSearch>> SearchShipment(string searchText, int page);
        Task<ServiceResponse<Shipment>> GetShipment(int productId);
    }
}
