using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.Basic;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Repositories.Hoangnv
{
    public class RecordProcessHoangNvRepo : GenericRepository<RecordProcessHoangNv>
    {
        public RecordProcessHoangNvRepo() => _context ??= new Su25Prn231Se1723G5Context();
        public RecordProcessHoangNvRepo(Su25Prn231Se1723G5Context context) => _context = context;
    
    }
}
