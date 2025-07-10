using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.FE.Hoangnv.Views.PlanQuitMethodHoangnv
{
    public class IndexModel : PageModel
    {
        private readonly QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context _context;

        public IndexModel(QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context context)
        {
            _context = context;
        }

        public IList<PlanQuitMethodHoangNv> PlanQuitMethodHoangNv { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PlanQuitMethodHoangNv = await _context.PlanQuitMethodHoangNvs
                .Include(p => p.CreatePlanQuitSmokingHoangNv)
                .Include(p => p.QuitMethodHoangNv).ToListAsync();
        }
    }
}
