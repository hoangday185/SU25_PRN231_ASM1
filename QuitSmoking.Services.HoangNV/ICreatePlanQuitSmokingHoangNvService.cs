using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Services.HoangNV
{
    public interface ICreatePlanQuitSmokingHoangNvService
    {
        Task<List<CreatePlanQuitSmokingHoangNv>> GetAllPlansAsync();

        Task<CreatePlanQuitSmokingHoangNv?> GetPlanByIdAsync(int id);

        Task<int> CreatePlanAsync(CreatePlanQuitSmokingHoangNv plan);

        Task<int> UpdatePlanAsync(CreatePlanQuitSmokingHoangNv plan);

        Task<bool> DeletePlanAsync(int id);

        Task<List<CreatePlanQuitSmokingHoangNv>> SearchAsync(string title);

        Task<PaginationResult<CreatePlanQuitSmokingHoangNv>> GetPaginatedPlansAsync(int page = 1, int pageSize = 10, string? planTitle = null, string? motivation = null, int? dailySmoking = null);
    }
}
