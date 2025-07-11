using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.Basic;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Repositories.Hoangnv
{
    public class QuitMethodHoangNvRepo : GenericRepository<QuitMethodHoangNv>
    {
        public QuitMethodHoangNvRepo() => _context ??= new Su25Prn231Se1723G5Context();
        public QuitMethodHoangNvRepo(Su25Prn231Se1723G5Context context) => _context = context;

        public IQueryable<QuitMethodHoangNv> GetQueryable() => _context.QuitMethodHoangNvs.AsQueryable();
    }
}
