using Microsoft.AspNetCore.Authorization;
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


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ContactAbout>>> AddCAboutNew(ContactAbout ship)
        {
            var result = await _contactAboutService.AddCAboutNew(ship);
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactAbout>>> GetAbout(int id)
        {
            var result = await _contactAboutService.GetAbout(id);
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAbout>>>> GetContactAdmin()
        {
            var result = await _contactAboutService.GetContactAdmin();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAbout>>>> DeleteSlide(int id)
        {
            var result = await _contactAboutService.DeleteAbout(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAbout>>>> AddAbout(ContactAbout slider)
        {
            var result = await _contactAboutService.AddAbout(slider);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<ContactAbout>>>> UpdateAbout(ContactAbout slider)
        {
            var result = await _contactAboutService.UpdateAbout(slider);
            return Ok(result);
        }




    }
}
