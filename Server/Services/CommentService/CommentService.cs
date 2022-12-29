namespace BlazorApp.Server.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context;
        }

        

        public async Task<ServiceResponse<List<Comment>>> GetCommentByProduct(int id)
        {
            var response = new ServiceResponse<List<Comment>>
            {
                Data = await _context.Comments.Where(p => p.ProductId == id &&
                p.Visible && !p.Deleted).ToListAsync()
            }; 
            return response;
        }
    }
}
