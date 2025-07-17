using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.Basic;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Repositories.Hoangnv 
{
    public class SystemUserRepo : GenericRepository<UserAccountHoangNv>
    {
        public SystemUserRepo() => _context ??= new Su25Prn231Se1723G5Context();

        public SystemUserRepo(Su25Prn231Se1723G5Context context) => _context = context;

        public async Task<UserAccountHoangNv> GetUserAccountAsync(string username, string password)   
            => await _context.UserAccountHoangNvs.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive);
        
    }
}
