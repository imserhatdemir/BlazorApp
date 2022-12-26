using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }


        [HttpPost("admin"), Authorize(Roles ="Admin")]
        public async Task<ActionResult<ServiceResponse<Shipment>>> CreateShipment(Shipment ship)
        {
            var result = await _shipmentService.CreateShipment(ship);
            return Ok(result);
        }

    }
}
