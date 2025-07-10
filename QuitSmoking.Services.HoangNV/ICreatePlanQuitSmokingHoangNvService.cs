using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;

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

        Task<PaginationResult<CreatePlanQuitSmokingHoangNv>> GetPaginatedPlansAsync(int page = 1, int pageSize = 10, string? planTitle = null, bool? isActive = null);   
    }
}
