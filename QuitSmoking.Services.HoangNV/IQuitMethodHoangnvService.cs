using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Services.HoangNV
{
    public interface IQuitMethodHoangnvService
    {
        
        
         Task<QuitMethodHoangNv?> GetMethodByIdAsync(int id);
         Task<int> CreateMethodAsync(QuitMethodHoangNv method);
         Task<int> UpdateMethodAsync(QuitMethodHoangNv method);
         Task<bool> DeleteMethodAsync(int id);
         
         Task<PaginationResult<QuitMethodHoangNv>> getMethodWithPaginationAsync(int page = 1, int pageSize = 10, string? search = null);

        Task<List<QuitMethodHoangNv>> GetListQuitMethodAsync(bool isActive = true);
    }
}
