namespace BlazorApp.Server.Services.HumanService
{
    public interface IHumanService
    {

        Task<ServiceResponse<List<HumanResources>>> GetHuman();
        Task<ServiceResponse<List<HumanResources>>> GetAdminHuman();
        Task<ServiceResponse<List<HumanResources>>> AddHuman(HumanResources human);
        Task<ServiceResponse<List<HumanResources>>> UpdateHuman(HumanResources human);
    }
}
