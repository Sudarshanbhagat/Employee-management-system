using EMS.Data.DTOs;

namespace EMS.Services.Interfaces
{
    public interface ILeaveService
    {
        Task<LeaveRequestDto?> GetLeaveByIdAsync(int id);
        Task<IEnumerable<LeaveRequestDto>> GetEmployeeLeavesAsync(int employeeId);
        Task<IEnumerable<LeaveRequestDto>> GetPendingLeavesAsync();
        Task<LeaveRequestDto> ApplyForLeaveAsync(int employeeId, CreateLeaveRequestDto dto);
        Task<bool> ApproveLeaveAsync(int leaveId, ApproveLeaveDto dto);
        Task<bool> RejectLeaveAsync(int leaveId);
    }
}
