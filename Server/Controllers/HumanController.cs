using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _human;

        public HumanController(IHumanService human)
        {
            _human = human;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HumanResources>>>> GetHuman()
        {
            var result = await _human.GetHuman();
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<HumanResources>>>> GetAdminHuman()
        {
            var result = await _human.GetAdminHuman();
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<HumanResources>>>> AddAbout(HumanResources human)
        {
            var result = await _human.AddHuman(human);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<HumanResources>>>> UpdateHuman(HumanResources human)
        {
            var result = await _human.UpdateHuman(human);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<HumanResources>>> GetFaqById(int id)
        {
            var result = await _human.GetFaqById(id);
            return Ok(result);
        }
    }
}
