namespace BlazorApp.Client.Services.MissionVisionService
{
    public interface IMissionVisionService
    {
        event Action OnChange;
        List<MissionVision> MissionVisions { get; set; }
        Task GetMissionVision();
    }
}
