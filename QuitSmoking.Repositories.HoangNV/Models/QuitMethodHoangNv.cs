using System;
using System.Collections.Generic;

namespace QuitSmoking.Repositories.HoangNV.Models;

public partial class QuitMethodHoangNv
{
    public int QuitMethodHoangNvid { get; set; }

    public string MethodName { get; set; } = null!;

    public string MethodDescription { get; set; } = null!;

    public int? EffectivenessRating { get; set; }

    public int? DifficultyLevel { get; set; }

    public int? RecommendedDuration { get; set; }

    public bool? RequiresMedical { get; set; }

    public bool? RequiresCounseling { get; set; }

    public bool? IsPopular { get; set; }

    public DateTime? CreationDateTime { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PlanQuitMethodHoangNv> PlanQuitMethodHoangNvs { get; set; } = new List<PlanQuitMethodHoangNv>();
}
