using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Services.HoangNV;

namespace QuitSmoking.API.HoangNV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuitMethodHoangnvController : ControllerBase
    {
        private readonly IQuitMethodHoangnvService _quitMethodService;
        public QuitMethodHoangnvController(IQuitMethodHoangnvService quitMethodService)
        {
            _quitMethodService = quitMethodService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var method = await _quitMethodService.GetMethodByIdAsync(id);
            if (method == null)
            {
                return NotFound();
            }
            return Ok(method);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuitMethodHoangNv method)
        {
            if (method == null)
            {
                return BadRequest("Invalid data.");
            }
            var createdId = await _quitMethodService.CreateMethodAsync(method);
            return CreatedAtAction(nameof(GetById), new { id = createdId }, method);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuitMethodHoangNv method)
        {
            if (method == null || method.QuitMethodHoangNvid != id)
            {
                return BadRequest("Invalid data.");
            }
            var updated = await _quitMethodService.UpdateMethodAsync(method);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _quitMethodService.DeleteMethodAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> List(int page, int pageSize, string? search)
        {
            if (page < 1) page = 1; // Ensure page is at least 1
            if (pageSize < 1) pageSize = 10; // Ensure pageSize is at least 1
            var result = await _quitMethodService.getMethodWithPaginationAsync(page, pageSize, search);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList(bool isActive = true)
        {
            var methods = await _quitMethodService.GetListQuitMethodAsync(isActive);
            return Ok(methods);
        }
    }
}
