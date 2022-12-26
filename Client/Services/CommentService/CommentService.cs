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

        public async Task<ServiceResponse<Comment>> GetComment(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Comment>>($"api/Comment/product/{id}");
            return result;
        }

    }
}
