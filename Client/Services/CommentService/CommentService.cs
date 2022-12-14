using BlazorApp.Client.Pages.Admin;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _http;

        public CommentService(HttpClient http)
        {
            _http = http;
        }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public event Action CommentsChanged;

        public async Task<ServiceResponse<Comment>> GetComment(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Comment>>($"api/Comment/product/{productId}/");
            return result;
        }

        public Task GetComments(int? productId = null)
        {
            throw new NotImplementedException();
        }
    }
}
