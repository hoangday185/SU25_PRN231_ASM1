using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuitSmoking.Repositories.Hoangnv;
using QuitSmoking.Repositories.HoangNV;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.Services.HoangNV
{
    public class UserService
    {
        public readonly SystemUserRepo _userRepo;

        public UserService() => _userRepo ??= new SystemUserRepo();

        public UserService(SystemUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserAccountHoangNv> loginAsync(string username, string password)
        {

            return await _userRepo.GetUserAccountAsync(username, password);
        }

        public async Task<UserAccountHoangNv> GetUserByIdAsync(int userId)
        {
            return await _userRepo.GetByIdAsync(userId);
        }
    }
}
