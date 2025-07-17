using System;
using System.Collections.Generic;

namespace QuitSmoking.Repositories.HoangNV.Models;

public partial class UserAccountHoangNv
{
    public int UserAccountHoangNvid { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string EmployeeCode { get; set; } = null!;

    public int RoleId { get; set; }

    public string? RequestCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ApplicationCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CreatePlanQuitSmokingHoangNv> CreatePlanQuitSmokingHoangNvs { get; set; } = new List<CreatePlanQuitSmokingHoangNv>();
}
