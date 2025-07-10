using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;

namespace QuitSmoking.Services.HoangNV
{
    public interface IPlanQuitHoangNVService
    {
        Task<List<PlanQuitMethodHoangNv>> GetAllPlansAsync();
        Task<PlanQuitMethodHoangNv?> GetPlanByIdAsync(int id);
        Task<int> CreatePlanAsync(PlanQuitMethodHoangNv plan);
        Task<int> UpdatePlanAsync(PlanQuitMethodHoangNv plan);
        Task<bool> DeletePlanAsync(int id);
        
        Task<IQueryable<PlanQuitMethodHoangNv>> GetQueryable();

        Task<PaginationResult<PlanQuitMethodHoangNv>> GetPaginatedPlansAsync(int page = 1, int pageSize = 10, int? createPlanId = null, string? search = null);
    }
}
