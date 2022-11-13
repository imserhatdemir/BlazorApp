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
        Task UpdateCategories(Category category);
        Task AddCategories(Category category);
        Category CreateNewCategory();
        
    }
}
