namespace BlazorApp.Server.Services.MissionVisionService
{
    public class MissionVisionService : IMissionVisionService   
    {
        private readonly DataContext _context;

        public MissionVisionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MissionVision>>> AddMissionVision(MissionVision missionVision)
        {
            missionVision.Editing = missionVision.IsNew = false;
            _context.MissionVisions.Add(missionVision);
            await _context.SaveChangesAsync();
            return await GetAdminMissionVision();
        }

        public async Task<ServiceResponse<List<MissionVision>>> GetAdminMissionVision()
        {
            var mv = await _context.MissionVisions
                 .ToListAsync();
            return new ServiceResponse<List<MissionVision>>
            {
                Data = mv
            };
        }

        private async Task<MissionVision> GetMissionById(int id)
        {
            return await _context.MissionVisions.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<ServiceResponse<List<MissionVision>>> GetMissionVision()
        {
            var about = await _context.MissionVisions.ToListAsync();
            return new ServiceResponse<List<MissionVision>>
            {
                Data = about
            };
        }

        public async Task<ServiceResponse<List<MissionVision>>> UpdateMissionVision(MissionVision missionVision)
        {
            var dbCategory = await GetMissionById(missionVision.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<MissionVision>>
                {
                    Success = false,
                    Message = "Mission and vision not found"
                };
            }
            dbCategory.TitleMission = missionVision.TitleMission;
            dbCategory.TitleVision = missionVision.TitleVision;
            dbCategory.DetailMission = missionVision.DetailMission;
            dbCategory.DetailVision = missionVision.DetailVision;
            dbCategory.ImageUrlVision = missionVision.ImageUrlVision;
            dbCategory.ImageUrlMission = missionVision.ImageUrlMission;
            await _context.SaveChangesAsync();
            return await GetAdminMissionVision();
        }
    }
}
