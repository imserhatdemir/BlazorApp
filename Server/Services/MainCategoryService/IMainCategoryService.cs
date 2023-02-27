namespace BlazorApp.Server.Services.MainCategoryService
{
    public interface IMainCategoryService
    {
        Task<ServiceResponse<List<MainCategory>>> GetMainCategories();
        Task<ServiceResponse<List<MainCategory>>> GetAdminMainCategories();
        Task<ServiceResponse<List<MainCategory>>> AddMainCategory(MainCategory category);
        Task<ServiceResponse<MainCategory>> UpdateMainCategory(MainCategory category);
        Task<ServiceResponse<List<MainCategory>>> DeleteMainCategory(int id);
        Task<ServiceResponse<MainCategory>> GetMainCategoryAsync(int catId);
        Task<ServiceResponse<MainCategory>> CreateMainCategory(MainCategory category);
    }
}
