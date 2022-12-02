using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<About>>>> GetAdminAbout()
        {
            var result = await _aboutService.GetAdminAbout();
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<About>>>> AddAbout(About about)
        {
            var result = await _aboutService.AddAbout(about);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<About>>>> UpdateAbout(About about)
        {
            var result = await _aboutService.UpdateAbout(about);
            return Ok(result);
        }
    }
}
