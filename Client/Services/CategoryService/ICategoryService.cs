namespace BlazorApp.Client.Services.CategoryService
{
    public interface ICategoryService
    {


        event Action OnChange;
        List<Category> Categories { get; set; }
        List<Category> AdminCategories { get; set; }
        Task GetCategories();
        Task GetAdminCategories();
        Task DeleteCategories(int categoryId);
        Task<Category> UpdateCategories(Category category);
        Task AddCategories(Category category);
        Category CreateNewCategory();
        Task<ServiceResponse<Category>> GetCategory(int catId);
        Task<Category> CreateCategory(Category category);



    }
}
