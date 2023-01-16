using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAddressController : ControllerBase
    {
        private readonly IContactAddressService _contactAddressService;

        public ContactAddressController(IContactAddressService contactAddressService)
        {
            _contactAddressService = contactAddressService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ContactAddress>>>> GetContactAddress()
        {
            var result = await _contactAddressService.GetContactAddress();
            return Ok(result);
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactAddress>>> GetAddress(int id)
        {
            var result = await _contactAddressService.GetAddress(id);
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAddress>>>> GetAdminAddress()
        {
            var result = await _contactAddressService.GetAdminAddress();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAddress>>>> DeleteAddress(int id)
        {
            var result = await _contactAddressService.DeleteAddress(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAddress>>>> AddAddress(ContactAddress slider)
        {
            var result = await _contactAddressService.AddAddress(slider);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAddress>>>> UpdateAddress(ContactAddress slider)
        {
            var result = await _contactAddressService.UpdateAddress(slider);
            return Ok(result);
        }
    }
}
