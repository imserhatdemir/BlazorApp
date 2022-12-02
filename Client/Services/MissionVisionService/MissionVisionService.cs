using BlazorApp.Client.Pages;
using BlazorApp.Shared;

namespace BlazorApp.Client.Services.MissionVisionService
{
    public class MissionVisionService : IMissionVisionService
    {
        private readonly HttpClient _httpClient;

        public MissionVisionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<MissionVision> MissionVisions { get; set; } = new List<MissionVision>();
        public List<MissionVision> AdminMissionVisions { get; set; } = new List<MissionVision>();

        public event Action OnChange;

        public async Task AddMissionVision(MissionVision missionVision)
        {
            var response = await _httpClient.PostAsJsonAsync("api/MissionVision/admin", missionVision);
            AdminMissionVisions = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<MissionVision>>>()).Data;
            await GetMissionVision();
            OnChange.Invoke();
        }

        public MissionVision CreateNewMissionVision()
        {
            var newCategory = new MissionVision { IsNew = true, Editing = true };
            AdminMissionVisions.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task GetAdminMissionVision()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<MissionVision>>>("api/MissionVision/admin");
            if (response != null && response.Data != null)
                AdminMissionVisions = response.Data;
        }

        public async Task GetMissionVision()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<MissionVision>>>("api/MissionVision");
            if (response != null && response.Data != null)
                MissionVisions = response.Data;
        }

        public async Task UpdateMissionVision(MissionVision missionVision)
        {
            var response = await _httpClient.PutAsJsonAsync("api/MissionVision/admin", missionVision);
            AdminMissionVisions = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<MissionVision>>>()).Data;
            await GetAdminMissionVision();
            OnChange.Invoke();
        }
    }
}
