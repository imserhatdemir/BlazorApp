using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Comment>>> GetCommentByProduct(int id)
        {
            var result = await _commentService.GetCommentByProduct(id);
            return Ok(result);
        }

      
    }
}
