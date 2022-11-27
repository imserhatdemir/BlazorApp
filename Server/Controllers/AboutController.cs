using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<About>>>> GetAbout()
        {
            var result = await _aboutService.GetAbout();
            return Ok(result);
        }
    }
}
