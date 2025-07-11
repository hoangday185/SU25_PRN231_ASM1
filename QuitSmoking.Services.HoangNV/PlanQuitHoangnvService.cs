using Microsoft.EntityFrameworkCore;
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
    public class PlanQuitHoangnvService : IPlanQuitHoangNVService
    {
        private readonly PlanQuitMethodHoangNvRepo _planQuitRepo;

        public PlanQuitHoangnvService() => _planQuitRepo ??= new PlanQuitMethodHoangNvRepo();
        public async Task<int> CreatePlanAsync(PlanQuitMethodHoangNv plan)
        {
            return await _planQuitRepo.CreateAsync(plan);
        }

        public async Task<bool> DeletePlanAsync(int id)
        {
            return await _planQuitRepo.RemoveAsync(new PlanQuitMethodHoangNv { PlanQuitMethodHoangNvid = id });
        }

        public async Task<List<PlanQuitMethodHoangNv>> GetAllPlansAsync()
        {
            return await _planQuitRepo.GetAllAsync();
        }

       
        public async Task<PlanQuitMethodHoangNv?> GetPlanByIdAsync(int id)
        {
            return await _planQuitRepo.GetByIdAsync(id);
        }

        public Task<IQueryable<PlanQuitMethodHoangNv>> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdatePlanAsync(PlanQuitMethodHoangNv plan)
        {
            return await _planQuitRepo.UpdateAsync(plan);
        }

        public async Task<PaginationResult<PlanQuitMethodHoangNv>> GetPaginatedPlansAsync(int page = 1, int pageSize = 10, int? createPlanId = null, string? search = null)
        {
            var query =  _planQuitRepo.GetQueryable();

            if(query == null)
            {
                return new PaginationResult<PlanQuitMethodHoangNv>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 1,
                    PageSize = 0,
                    Items = new List<PlanQuitMethodHoangNv>()
                };
            }

            if (createPlanId.HasValue)
            {
                query = query.Where(p => p.CreatePlanQuitSmokingHoangNvid == createPlanId);
            }

            

            if (!string.IsNullOrWhiteSpace(search))
            {
                string keyword = search.Trim().ToLower();
                query = query.Where(p => p.UserNotes.ToLower().Contains(keyword));
            }

            var items = await query
             .OrderByDescending(p => p.CreationDateTime)
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);


            return new PaginationResult<PlanQuitMethodHoangNv>
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
