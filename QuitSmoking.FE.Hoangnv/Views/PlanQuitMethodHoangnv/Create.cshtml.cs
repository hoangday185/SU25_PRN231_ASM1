using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuitSmoking.Repositories.HoangNV.Models;

namespace QuitSmoking.FE.Hoangnv.Views.PlanQuitMethodHoangnv
{
    public class CreateModel : PageModel
    {
        private readonly QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context _context;

        public CreateModel(QuitSmoking.Repositories.HoangNV.Models.Su25Prn231Se1723G5Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CreatePlanQuitSmokingHoangNvid"] = new SelectList(_context.CreatePlanQuitSmokingHoangNvs, "CreatePlanQuitSmokingHoangNvid", "MotivationReason");
        ViewData["QuitMethodHoangNvid"] = new SelectList(_context.QuitMethodHoangNvs, "QuitMethodHoangNvid", "MethodDescription");
            return Page();
        }

        [BindProperty]
        public PlanQuitMethodHoangNv PlanQuitMethodHoangNv { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlanQuitMethodHoangNvs.Add(PlanQuitMethodHoangNv);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
