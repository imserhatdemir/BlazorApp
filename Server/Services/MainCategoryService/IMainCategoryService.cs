namespace BlazorApp.Server.Services.MainCategoryService
{
    public interface IMainCategoryService
    {
        Task<ServiceResponse<List<MainCategory>>> GetMainCategory();
        Task<ServiceResponse<List<MainCategory>>> GetAdminMainCategories();
        Task<ServiceResponse<List<MainCategory>>> AddMainCategory(MainCategory category);
        Task<ServiceResponse<List<MainCategory>>> UpdateMainCategory(MainCategory category);
        Task<ServiceResponse<List<MainCategory>>> DeleteMainCategory(int id);
    }
}
