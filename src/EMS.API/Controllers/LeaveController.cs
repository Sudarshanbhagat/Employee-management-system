using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using EMS.Data.DTOs;
using EMS.Services.Interfaces;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetById(int id)
        {
            var leave = await _leaveService.GetLeaveByIdAsync(id);
            if (leave == null)
                return NotFound();
            return Ok(leave);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetByEmployee(int employeeId)
        {
            var leaves = await _leaveService.GetEmployeeLeavesAsync(employeeId);
            return Ok(leaves);
        }

        [HttpGet("pending")]
        [Authorize(Roles = "Admin,HR,Manager")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetPending()
        {
            var leaves = await _leaveService.GetPendingLeavesAsync();
            return Ok(leaves);
        }

        [HttpPost("apply")]
        public async Task<ActionResult<LeaveRequestDto>> Apply([FromBody] CreateLeaveRequestDto dto)
        {
            var employeeId = int.Parse(User.FindFirst("EmployeeId")?.Value ?? "0");
            if (employeeId == 0)
                return Unauthorized();

            var leave = await _leaveService.ApplyForLeaveAsync(employeeId, dto);
            return CreatedAtAction(nameof(GetById), new { id = leave.Id }, leave);
        }

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin,HR,Manager")]
        public async Task<IActionResult> Approve(int id, [FromBody] ApproveLeaveDto dto)
        {
            var result = await _leaveService.ApproveLeaveAsync(id, dto);
            if (!result)
                return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/reject")]
        [Authorize(Roles = "Admin,HR,Manager")]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await _leaveService.RejectLeaveAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
