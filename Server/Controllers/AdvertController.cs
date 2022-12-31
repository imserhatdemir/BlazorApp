using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Advert>>>> GetAdminAdvert()
        {
            var result = await _advertService.GetAdminAdvert();
            return Ok(result);
        }


        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Advert>>> CreateAdvert(Advert advert)
        {
            var result = await _advertService.CreateAdvert(advert);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Advert>>> UpdateAdvert(Advert advert)
        {
            var result = await _advertService.UpdateAdvert(advert);
            return Ok(result);
        }

        [HttpDelete("{Id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAdvert(int Id)
        {
            var result = await _advertService.DeleteAdvert(Id);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Advert>>> GetProduct(int id)
        {
            var result = await _advertService.GetAdvertById(id);
            return Ok(result);
        }



    }
}
