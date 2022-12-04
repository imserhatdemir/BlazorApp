using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Brand>>>> GetBrands()
        {
            var result = await _brandService.GetBrands();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Brand>>>> GetAdminBrands()
        {
            var result = await _brandService.GetAdminBrands();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Brand>>>> DeleteBrand(int id)
        {
            var result = await _brandService.DeleteBrand(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Brand>>>> AddBrand(Brand brand)
        {
            var result = await _brandService.AddBrand(brand);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Brand>>>> UpdateCategory(Brand brand)
        {
            var result = await _brandService.UpdateBrand(brand);
            return Ok(result);
        }

    }
}
