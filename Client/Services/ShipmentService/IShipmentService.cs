namespace BlazorApp.Client.Services.ShipmentService
{
    public interface IShipmentService
    {
        event Action OnChanged;
        List<Shipment> Shipments { get; set; }
        string Message { get; set; }
        Task<ServiceResponse<Shipment>> GetShipment(int shipId);
        Task GetAdminShip();
        Task GetShipAsync();
        Task<Shipment> CreateShipment(Shipment ship);
        Task<Shipment> UpdateShip(Shipment ship);
        Task DeleteShip(Shipment shipId);
    }
}
