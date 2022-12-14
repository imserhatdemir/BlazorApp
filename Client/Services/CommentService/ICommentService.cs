namespace BlazorApp.Client.Services.CommentService
{
    public interface ICommentService
    {
        event Action CommentsChanged;
        List<Comment> Comments { get; set; }
        Task GetComments(int? productId = null);
        Task<ServiceResponse<Comment>> GetComment(int productId);

    }
}
