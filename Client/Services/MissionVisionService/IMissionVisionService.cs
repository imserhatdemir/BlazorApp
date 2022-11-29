namespace BlazorApp.Client.Services.MissionVisionService
{
    public interface IMissionVisionService
    {
        List<MissionVision> MissionVisions { get; set; }
        Task GetMissionVision();
    }
}
