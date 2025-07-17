using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repositories.Hoangnv;
using QuitSmoking.Repositories.HoangNV;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Services.HoangNV
{
    public class QuitMethodHoangnvService : IQuitMethodHoangnvService
    {
        private readonly QuitMethodHoangNvRepo _methodRepo;

        public QuitMethodHoangnvService() => _methodRepo ??= new QuitMethodHoangNvRepo();

        public async Task<int> CreateMethodAsync(QuitMethodHoangNv method) => await _methodRepo.CreateAsync(method);

        public async Task<bool> DeleteMethodAsync(int id)
        {
            var method = await _methodRepo.GetByIdAsync(id);
            if (method == null)
                return false;
            method.IsActive = false;
            await _methodRepo.UpdateAsync(method);
            return true;
        }

        public async Task<List<QuitMethodHoangNv>> GetListQuitMethodAsync(bool isActive = true) 
            => await _methodRepo.GetQueryable().Where(m => m.IsActive == isActive)
                .ToListAsync();
        

        public async Task<QuitMethodHoangNv?> GetMethodByIdAsync(int id) => await _methodRepo.GetByIdAsync(id);

        public async Task<PaginationResult<QuitMethodHoangNv>> getMethodWithPaginationAsync(int page = 1, int pageSize = 10, string? search = null)
        {
            var query = _methodRepo.GetQueryable();

            //if (string.IsNullOrEmpty(search))
            //{
            //    query
            //}

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .OrderByDescending(p => p.CreationDateTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationResult<QuitMethodHoangNv>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Items = items
            };


        }

        public async Task<int> UpdateMethodAsync(QuitMethodHoangNv method)
        {
            return await _methodRepo.UpdateAsync(method);
        }
    }
}
