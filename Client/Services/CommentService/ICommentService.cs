namespace BlazorApp.Client.Services.CommentService
{
    public interface ICommentService
    {
        event Action CommentsChanged;
        List<Comment> Comments { get; set; }
        Task<ServiceResponse<Comment>> GetComment(int productId);

    }
}
