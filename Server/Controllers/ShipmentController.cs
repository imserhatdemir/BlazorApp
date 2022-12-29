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


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Shipment>>> CreateShipment(Shipment ship)
        {
            var result = await _shipmentService.CreateShipment(ship);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Shipment>>> GetAdminShipment()
        {
            var result = await _shipmentService.GetAdminShipment();
            return Ok(result);
        }


        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Shipment>>> UpdateShipment(Shipment ship)
        {
            var result = await _shipmentService.UpdateShipment(ship);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Shipment>>> GetShipment(int id)
        {
            var result = await _shipmentService.GetShipment(id);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteShipment(int id)
        {
            var result = await _shipmentService.DeleteShipment(id);
            return Ok(result);
        }

        [HttpGet("{searchText}")]
        public async Task<ActionResult<ServiceResponse<ShipmentSearch>>> SearchShip(string searchText)
        {
            var result = await _shipmentService.SearchShipment(searchText);
            return Ok(result);
        }

    }
}
