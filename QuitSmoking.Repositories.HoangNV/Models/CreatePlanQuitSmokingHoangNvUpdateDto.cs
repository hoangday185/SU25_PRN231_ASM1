namespace QuitSmoking.Repositories.HoangNV.Models;

public class CreatePlanQuitSmokingHoangNvUpdateDto
{
    public int CreatePlanQuitSmokingHoangNvid { get; set; }
    public int UserAccountHoangNvid { get; set; }
    public string PlanTitle { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly TargetEndDate { get; set; }
    public int CurrentSmokingFrequency { get; set; }
    public int? DailyReductionGoal { get; set; }
    public string MotivationReason { get; set; } = null!;
    public string SelectedApproach { get; set; } = null!;
    public bool? IsActive { get; set; }
    public DateTime? CreationDateTime { get; set; }
} 