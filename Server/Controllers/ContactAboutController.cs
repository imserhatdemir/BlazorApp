using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAboutController : ControllerBase
    {
        private readonly IContactAboutService _contactAboutService;

        public ContactAboutController(IContactAboutService contactAboutService)
        {
            _contactAboutService = contactAboutService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ContactAbout>>>> GetContactAbout()
        {
            var result = await _contactAboutService.GetContactAbout();
            return Ok(result);
        }
    }
}
