using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Slider>>>> GetSlide()
        {
            var result = await _sliderService.GetSlide();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Slider>>> CreateShipment(Slider ship)
        {
            var result = await _sliderService.AddSliderNew(ship);
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Slider>>> GetSlider(int id)
        {
            var result = await _sliderService.GetSlider(id);
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Slider>>>> GetAdminSlide()
        {
            var result = await _sliderService.GetAdminSlide();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Slider>>>> DeleteSlide(int id)
        {
            var result = await _sliderService.DeleteSlide(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Slider>>>> AddCategory(Slider slider)
        {
            var result = await _sliderService.AddSlide(slider);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Slider>>>> UpdateAbout(Slider slider)
        {
            var result = await _sliderService.UpdateSlide(slider);
            return Ok(result);
        }


    }
}
