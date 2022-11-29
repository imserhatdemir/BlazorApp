using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionVisionController : ControllerBase
    {
        private readonly IMissionVisionService _missionVisionService;

        public MissionVisionController(IMissionVisionService missionVisionService)
        {
            _missionVisionService = missionVisionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MissionVision>>>> GetMissionVision()
        {
            var result = await _missionVisionService.GetMissionVision();
            return Ok(result);
        }


    }
}
