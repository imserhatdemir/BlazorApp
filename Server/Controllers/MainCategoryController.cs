using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
    {
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MainCategory>>>> GetMainCategory()
        {
            var result = await _mainCategoryService.GetMainCategory();
            return Ok(result);
        }



        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MainCategory>>>> GetAdminMainCategories()
        {
            var result = await _mainCategoryService.GetAdminMainCategories();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MainCategory>>>> DeleteMainCategory(int id)
        {
            var result = await _mainCategoryService.DeleteMainCategory(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MainCategory>>>> AddMainCategory(MainCategory category)
        {
            var result = await _mainCategoryService.AddMainCategory(category);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MainCategory>>>> UpdateMainCategory(MainCategory category)
        {
            var result = await _mainCategoryService.UpdateMainCategory(category);
            return Ok(result);
        }
    }
}
