namespace BlazorApp.Client.Services.HumanService
{
    public interface IHumanService
    {
        event Action OnChange;
        List<HumanResources> MainHumans { get; set; }
        List<HumanResources> AdminHumans { get; set; }
        Task GetHumans();
        Task GetAdminHumans();
        Task UpdateHuman(HumanResources human);
        Task AddHuman(HumanResources human);
        HumanResources CreateNewHuman();
    }
}
