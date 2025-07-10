using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Services.HoangNV;

namespace QuitSmoking.API.HoangNV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePlanHoangnvController : ControllerBase
    {
        private readonly ICreatePlanQuitSmokingHoangNvService _createPlanSerivce;
        private readonly UserService _userService;

        public CreatePlanHoangnvController(ICreatePlanQuitSmokingHoangNvService createPlanSerivce, UserService userService)
        {
            _createPlanSerivce = createPlanSerivce;
            _userService = userService; // Assuming UserService is properly implemented and registered
        }

        [HttpGet]
        public async Task<PaginationResult<CreatePlanQuitSmokingHoangNv>> GetWithPaginate([FromQuery] int page, [FromQuery] int pageSize, string? title, bool? isActive)
        {
            if (page < 1) page = 1; // Ensure page is at least 1
            if (pageSize < 1) pageSize = 10; // Ensure pageSize is at least 1
            return await _createPlanSerivce.GetPaginatedPlansAsync(page, pageSize, title, isActive);
            
        }

        [HttpGet("{id}")]
        public async Task<CreatePlanQuitSmokingHoangNv> Get(int id)
        {
            return await _createPlanSerivce.GetPlanByIdAsync(id); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlanQuitSmokingHoangNvCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Model is null");
            }
            var model = new CreatePlanQuitSmokingHoangNv
            {
                UserAccountHoangNvid = dto.UserAccountHoangNvid,
                PlanTitle = dto.PlanTitle,
                StartDate = dto.StartDate,
                TargetEndDate = dto.TargetEndDate,
                CurrentSmokingFrequency = dto.CurrentSmokingFrequency,
                DailyReductionGoal = dto.DailyReductionGoal,
                MotivationReason = dto.MotivationReason,
                SelectedApproach = dto.SelectedApproach
                // KHÔNG gán UserAccountHoangNv
            };
            var result = await _createPlanSerivce.CreatePlanAsync(model);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(500, "Tạo kế hoạch thất bại");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePlanQuitSmokingHoangNvUpdateDto dto)
        {
            if (dto == null || dto.CreatePlanQuitSmokingHoangNvid != id)
                return BadRequest("Invalid data");

            var model = new CreatePlanQuitSmokingHoangNv
            {
                CreatePlanQuitSmokingHoangNvid = dto.CreatePlanQuitSmokingHoangNvid,
                UserAccountHoangNvid = dto.UserAccountHoangNvid,
                PlanTitle = dto.PlanTitle,
                StartDate = dto.StartDate,
                TargetEndDate = dto.TargetEndDate,
                CurrentSmokingFrequency = dto.CurrentSmokingFrequency,
                DailyReductionGoal = dto.DailyReductionGoal,
                MotivationReason = dto.MotivationReason,
                SelectedApproach = dto.SelectedApproach,
                IsActive = dto.IsActive,
                CreationDateTime = dto.CreationDateTime
                // KHÔNG gán UserAccountHoangNv
            };
            var result = await _createPlanSerivce.UpdatePlanAsync(model);
            if (result > 0)
                return Ok();
            else if (result == 0)
                return NotFound();
            return StatusCode(500, "Cập nhật kế hoạch thất bại");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plan = await _createPlanSerivce.GetPlanByIdAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            plan.IsActive = false;
            var result = await _createPlanSerivce.UpdatePlanAsync(plan);
            if (result > 0)
            {
                return Ok();
            }
            return StatusCode(500, "Xóa kế hoạch thất bại");
        }
    }
}
