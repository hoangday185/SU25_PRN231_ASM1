using System;
using System.Collections.Generic;

namespace QuitSmoking.Repositories.HoangNV.Models;

public partial class RecordProcessHoangNv
{
    public int RecordProcessHoangNvid { get; set; }

    public int CreatePlanQuitSmokingHoangNvid { get; set; }

    public DateOnly RecordDate { get; set; }

    public int ActualCigarettesSmoked { get; set; }

    public int PlannedCigarettesLimit { get; set; }

    public bool? IsGoalAchieved { get; set; }

    public int? CravingLevel { get; set; }

    public string? TriggerSituations { get; set; }

    public decimal DailySavings { get; set; }

    public string? DailyNotes { get; set; }

    public DateTime? CreationDateTime { get; set; }

    public virtual CreatePlanQuitSmokingHoangNv CreatePlanQuitSmokingHoangNv { get; set; } = null!;
}
