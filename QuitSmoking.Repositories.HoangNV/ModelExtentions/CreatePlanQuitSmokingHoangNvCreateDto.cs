namespace QuitSmoking.Repositories.HoangNV.ModelExtentions;

public class CreatePlanQuitSmokingHoangNvCreateDto
{
    public int UserAccountHoangNvid { get; set; }
    public string PlanTitle { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly TargetEndDate { get; set; }
    public int CurrentSmokingFrequency { get; set; }
    public int? DailyReductionGoal { get; set; }
    public string MotivationReason { get; set; } = null!;
    public string SelectedApproach { get; set; } = null!;
} 