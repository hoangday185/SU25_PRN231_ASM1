using System;

namespace QuitSmoking.Repositories.HoangNV.ModelExtentions
{
    public class PlanQuitMethodHoangNvCreateDto
    {
        public int CreatePlanQuitSmokingHoangNvid { get; set; }
        public int QuitMethodHoangNvid { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool? IsSuccessful { get; set; }
        public int? UserRating { get; set; }
        public string? UserNotes { get; set; }
    }
} 