namespace BlazorApp.Server.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly DataContext _context;

        public ShipmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Shipment>> CreateShipment(Shipment ship)
        {
            _context.Shipments.Add(ship);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Shipment> { Data = ship };
        }

        public Task<ServiceResponse<bool>> DeleteShipment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Shipment>>> GetAdminShipment()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ShipmentSearch>> SearchShipment(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Shipment>> UpdateShipment(Shipment ship)
        {
            throw new NotImplementedException();
        }
    }
}
