using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repositories.HoangNV;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Services.HoangNV
{
    public class CreatePlanQuitSmokingHoangNvService : ICreatePlanQuitSmokingHoangNvService
    {
        private readonly CreatePlanQuitSmokingHoangNvRepo _planRepo;

        public CreatePlanQuitSmokingHoangNvService() => _planRepo ??= new CreatePlanQuitSmokingHoangNvRepo();

        public CreatePlanQuitSmokingHoangNvService(CreatePlanQuitSmokingHoangNvRepo planRepo)
        {
            _planRepo = planRepo;
        }
        public async Task<int> CreatePlanAsync(CreatePlanQuitSmokingHoangNv plan)
        {
            return await _planRepo.CreateAsync(plan);
        }

        public async Task<bool> DeletePlanAsync(int id)
        {
            return await _planRepo.RemoveAsync(new CreatePlanQuitSmokingHoangNv { CreatePlanQuitSmokingHoangNvid = id });
        }

        public async Task<List<CreatePlanQuitSmokingHoangNv>> GetAllPlansAsync()
        {
            return await _planRepo.GetAllAsync();
        }

        public async Task<CreatePlanQuitSmokingHoangNv?> GetPlanByIdAsync(int id)
        {
            return await _planRepo.GetByIdAsync(id);
        }

        public async Task<List<CreatePlanQuitSmokingHoangNv>> SearchAsync(string title)
        {
            return await _planRepo.SearchAsync(title);
        }

        public async Task<int> UpdatePlanAsync(CreatePlanQuitSmokingHoangNv plan)
        {
            return await _planRepo.UpdateAsync(plan);
        }

        public async Task<PaginationResult<CreatePlanQuitSmokingHoangNv>> GetPaginatedPlansAsync(int page = 1, int pageSize = 10, string? planTitle = null, bool? isActive = null)
        {
            var query = _planRepo.GetQueryable();

            if (!string.IsNullOrWhiteSpace(planTitle))
            {
                string keyword = planTitle.Trim().ToLower();
                query = query.Where(p => p.PlanTitle.ToLower().Contains(keyword));
            }

            if (isActive.HasValue)
            {
                query = query.Where(p => p.IsActive == isActive.Value);
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .OrderByDescending(p => p.CreationDateTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationResult<CreatePlanQuitSmokingHoangNv>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Items = items
            };
        }
    }
}
