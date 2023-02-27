namespace BlazorApp.Client.Services.MainCategoryService
{
    public interface IMainCategoryService
    {
        event Action OnChange;
        List<MainCategory> MainCategories { get; set; }
        List<MainCategory> AdminMainCategories { get; set; }
        Task GetMainCategories();
        Task GetAdminMainCategories();
        Task DeleteMainCategories(int categoryId);
        Task<MainCategory> UpdateCategories(MainCategory category);
        Task AddMainCategories(MainCategory category);
        MainCategory CreateNewMainCategory();
        
    }
}
