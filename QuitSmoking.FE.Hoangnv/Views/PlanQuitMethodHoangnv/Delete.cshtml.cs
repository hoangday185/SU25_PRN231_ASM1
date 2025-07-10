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
    public class DeleteModel : PageModel
    {
        private readonly QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context _context;

        public DeleteModel(QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context context)
        {
            _context = context;
        }

        [BindProperty]
        public PlanQuitMethodHoangNv PlanQuitMethodHoangNv { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planquitmethodhoangnv = await _context.PlanQuitMethodHoangNvs.FirstOrDefaultAsync(m => m.PlanQuitMethodHoangNvid == id);

            if (planquitmethodhoangnv == null)
            {
                return NotFound();
            }
            else
            {
                PlanQuitMethodHoangNv = planquitmethodhoangnv;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planquitmethodhoangnv = await _context.PlanQuitMethodHoangNvs.FindAsync(id);
            if (planquitmethodhoangnv != null)
            {
                PlanQuitMethodHoangNv = planquitmethodhoangnv;
                _context.PlanQuitMethodHoangNvs.Remove(PlanQuitMethodHoangNv);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
