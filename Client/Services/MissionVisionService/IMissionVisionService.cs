namespace BlazorApp.Client.Services.MissionVisionService
{
    public interface IMissionVisionService
    {
        event Action OnChange;
        List<MissionVision> MissionVisions { get; set; }
        List<MissionVision> AdminMissionVisions { get; set; }
        Task GetMissionVision();
        Task GetAdminMissionVision();
        Task UpdateMissionVision(MissionVision missionVision);
        Task AddMissionVision(MissionVision missionVision);
        MissionVision CreateNewMissionVision();
    }
}
