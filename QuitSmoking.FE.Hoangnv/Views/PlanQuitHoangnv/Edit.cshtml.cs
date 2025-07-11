using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.FE.Hoangnv.Views.PlanQuitMethodHoangnv
{
    public class EditModel : PageModel
    {
        private readonly QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context _context;

        public EditModel(QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context context)
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

            var planquitmethodhoangnv =  await _context.PlanQuitMethodHoangNvs.FirstOrDefaultAsync(m => m.PlanQuitMethodHoangNvid == id);
            if (planquitmethodhoangnv == null)
            {
                return NotFound();
            }
            PlanQuitMethodHoangNv = planquitmethodhoangnv;
           ViewData["CreatePlanQuitSmokingHoangNvid"] = new SelectList(_context.CreatePlanQuitSmokingHoangNvs, "CreatePlanQuitSmokingHoangNvid", "MotivationReason");
           ViewData["QuitMethodHoangNvid"] = new SelectList(_context.QuitMethodHoangNvs, "QuitMethodHoangNvid", "MethodDescription");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlanQuitMethodHoangNv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanQuitMethodHoangNvExists(PlanQuitMethodHoangNv.PlanQuitMethodHoangNvid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlanQuitMethodHoangNvExists(int id)
        {
            return _context.PlanQuitMethodHoangNvs.Any(e => e.PlanQuitMethodHoangNvid == id);
        }
    }
}
