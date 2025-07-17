using System;
using System.Collections.Generic;

namespace QuitSmoking.Repositories.HoangNV.Models;

public partial class PlanQuitMethodHoangNv
{
    public int PlanQuitMethodHoangNvid { get; set; }

    public int CreatePlanQuitSmokingHoangNvid { get; set; }

    public int QuitMethodHoangNvid { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? IsSuccessful { get; set; }

    public int? UserRating { get; set; }

    public string? UserNotes { get; set; }

    public DateTime? CreationDateTime { get; set; }

    public virtual CreatePlanQuitSmokingHoangNv CreatePlanQuitSmokingHoangNv { get; set; } = null!;

    public virtual QuitMethodHoangNv QuitMethodHoangNv { get; set; } = null!;
}
