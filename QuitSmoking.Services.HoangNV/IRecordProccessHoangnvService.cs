using QuitSmoking.Repositories.HoangNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Services.HoangNV
{
    public interface IRecordProccessHoangnvService
    {
        Task<List<RecordProcessHoangNv>> ListProccess();
    }
}
