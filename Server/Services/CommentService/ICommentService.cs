namespace BlazorApp.Server.Services.CommentService
{
    public interface ICommentService
    {
        Task<ServiceResponse<List<Comment>>> GetCommentByProduct(int id);
    }
}
