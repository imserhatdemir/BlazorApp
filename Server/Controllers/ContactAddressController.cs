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
    }
}
