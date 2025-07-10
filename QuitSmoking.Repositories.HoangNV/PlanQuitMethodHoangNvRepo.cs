using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repositories.HoangNV.Basic;
using QuitSmoking.Repositories.HoangNV.Models;
namespace QuitSmoking.Repositories.HoangNV
{
    public class PlanQuitMethodHoangNvRepo : GenericRepository<PlanQuitMethodHoangNv>
    {
        public PlanQuitMethodHoangNvRepo() => _context ??= new Su25Prn231Se1723G5Context();
        public PlanQuitMethodHoangNvRepo(Su25Prn231Se1723G5Context context) => _context = context;

        public IQueryable<PlanQuitMethodHoangNv> GetQueryable()
        {
            return _context.PlanQuitMethodHoangNvs
                .Include(p => p.QuitMethodHoangNv)
                .AsQueryable();
        }

    }
}
