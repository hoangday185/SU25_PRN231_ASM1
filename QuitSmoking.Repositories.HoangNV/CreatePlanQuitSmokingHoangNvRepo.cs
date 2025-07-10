
using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repositories.HoangNV.Basic;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Repositories.HoangNV
{
    public class CreatePlanQuitSmokingHoangNvRepo : GenericRepository<CreatePlanQuitSmokingHoangNv>
    {
        public CreatePlanQuitSmokingHoangNvRepo() => _context ??= new Su25Prn231Se1723G5Context();

        public CreatePlanQuitSmokingHoangNvRepo(Su25Prn231Se1723G5Context context) => _context = context;
        public async Task<CreatePlanQuitSmokingHoangNv?> GetPlanByIdAsync(int id)
            => await _context.CreatePlanQuitSmokingHoangNvs.Include(p => p.RecordProcessHoangNvs)
                .FirstOrDefaultAsync(p => p.CreatePlanQuitSmokingHoangNvid == id);
        public async Task<List<CreatePlanQuitSmokingHoangNv>> GetAllPlansAsync()
            => await _context.CreatePlanQuitSmokingHoangNvs.Include(p => p.RecordProcessHoangNvs).ToListAsync();

        public async Task<List<CreatePlanQuitSmokingHoangNv>> SearchAsync(string title) => await _context.CreatePlanQuitSmokingHoangNvs
                .Where(p => p.PlanTitle.Contains(title, StringComparison.OrdinalIgnoreCase))
                .Include(p => p.RecordProcessHoangNvs)
                .ToListAsync();
        public async Task<int> CountAsync()
        {
            return await _context.CreatePlanQuitSmokingHoangNvs.CountAsync();    
        }

        public async Task<List<CreatePlanQuitSmokingHoangNv>> GetPaginatedAsync(int page, int pageSize, string? planTitle)
        {
            var query = _context.CreatePlanQuitSmokingHoangNvs
                .Include(p => p.RecordProcessHoangNvs)
                .AsQueryable();

            // Lọc theo title nếu có
            if (!string.IsNullOrWhiteSpace(planTitle))
            {
                string keyword = planTitle.Trim().ToLower();
                query = query.Where(p => p.PlanTitle.ToLower().Contains(keyword));
                // Hoặc dùng EF.Functions.Like nếu muốn tối ưu cho SQL Server:
                // query = query.Where(p => EF.Functions.Like(p.PlanTitle, $"%{keyword}%"));
            }

            // Sắp xếp theo ngày tạo mới nhất
            query = query.OrderByDescending(p => p.CreationDateTime);

            // Phân trang
            var result = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }

        public IQueryable<CreatePlanQuitSmokingHoangNv> GetQueryable()
        {
            return _context.CreatePlanQuitSmokingHoangNvs
                .Include(p => p.RecordProcessHoangNvs)
                .AsQueryable();
        }
    }
}
