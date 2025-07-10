using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Services.HoangNV;

namespace QuitSmoking.API.HoangNV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanQuitHoangnvController : ControllerBase
    {
        private readonly IPlanQuitHoangNVService _planQuitMethodService;
        private readonly UserService _userService;

        public PlanQuitHoangnvController(IPlanQuitHoangNVService planQuitMethodService, UserService userService)
        {
            _planQuitMethodService = planQuitMethodService;
            _userService = userService; // Assuming UserService is properly implemented and registered
        }

        [HttpGet]
        public async Task<PaginationResult<PlanQuitMethodHoangNv>> List([FromQuery] int page, [FromQuery] int pageSize, int createPlanId, string? search)
        {
            if (page < 1) page = 1; // Ensure page is at least 1
            if (pageSize < 1) pageSize = 10; // Ensure pageSize is at least 1
            return await _planQuitMethodService.GetPaginatedPlansAsync(page, pageSize,createPlanId, search);
        }

        [HttpGet("{id}")]
        public async Task<PlanQuitMethodHoangNv?> Get(int id)
        {
            return await _planQuitMethodService.GetPlanByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlanQuitMethodHoangNv plan)
        {
            if (plan == null)
            {
                return BadRequest("Model is null");
            }
            var result = await _planQuitMethodService.CreatePlanAsync(plan);
            if (result > 0)
            {
                return CreatedAtAction(nameof(Get), new { id = result }, plan);
            }
            return BadRequest("Failed to create plan");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlanQuitMethodHoangNv plan)
        {
            if (plan == null || plan.PlanQuitMethodHoangNvid != id)
            {
                return BadRequest("Model is null or ID mismatch");
            }
            var result = await _planQuitMethodService.UpdatePlanAsync(plan);
            if (result > 0)
            {
                return NoContent(); // 204 No Content
            }
            return NotFound("Plan not found or update failed");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _planQuitMethodService.DeletePlanAsync(id);
            if (result)
            {
                return NoContent(); // 204 No Content
            }
            return NotFound("Plan not found or delete failed");
        }
    }
}
