using EMS.Data.DTOs;
using EMS.Data.Models;
using EMS.Data.Repositories;
using EMS.Services.Interfaces;
using EMS.Common.Exceptions;

namespace EMS.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRequestRepository _leaveRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public LeaveService(
            ILeaveRequestRepository leaveRepository,
            IEmployeeRepository employeeRepository)
        {
            _leaveRepository = leaveRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<LeaveRequestDto?> GetLeaveByIdAsync(int id)
        {
            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null)
                return null;

            return MapToDto(leave);
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetEmployeeLeavesAsync(int employeeId)
        {
            var leaves = await _leaveRepository.GetByEmployeeAsync(employeeId);
            return leaves.Select(MapToDto).ToList();
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetPendingLeavesAsync()
        {
            var leaves = await _leaveRepository.GetPendingAsync();
            return leaves.Select(MapToDto).ToList();
        }

        public async Task<LeaveRequestDto> ApplyForLeaveAsync(int employeeId, CreateLeaveRequestDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                throw new NotFoundException($"Employee with id {employeeId} not found");

            if (dto.StartDate >= dto.EndDate)
                throw new BadRequestException("Start date must be before end date");

            var leaveRequest = new LeaveRequest
            {
                EmployeeId = employeeId,
                LeaveTypeId = dto.LeaveTypeId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _leaveRepository.CreateAsync(leaveRequest);
            return MapToDto(leaveRequest);
        }

        public async Task<bool> ApproveLeaveAsync(int leaveId, ApproveLeaveDto dto)
        {
            var leave = await _leaveRepository.GetByIdAsync(leaveId);
            if (leave == null)
                throw new NotFoundException($"Leave request with id {leaveId} not found");

            leave.Status = dto.IsApproved ? "Approved" : "Rejected";
            leave.ApprovedDate = DateTime.UtcNow;
            leave.UpdatedAt = DateTime.UtcNow;

            await _leaveRepository.UpdateAsync(leave);
            return true;
        }

        public async Task<bool> RejectLeaveAsync(int leaveId)
        {
            var leave = await _leaveRepository.GetByIdAsync(leaveId);
            if (leave == null)
                throw new NotFoundException($"Leave request with id {leaveId} not found");

            leave.Status = "Rejected";
            leave.UpdatedAt = DateTime.UtcNow;

            await _leaveRepository.UpdateAsync(leave);
            return true;
        }

        private static LeaveRequestDto MapToDto(LeaveRequest leave)
        {
            return new LeaveRequestDto
            {
                Id = leave.Id,
                EmployeeId = leave.EmployeeId,
                EmployeeName = $"{leave.Employee?.FirstName} {leave.Employee?.LastName}",
                LeaveTypeId = leave.LeaveTypeId,
                LeaveTypeName = leave.LeaveType?.Name ?? string.Empty,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                Status = leave.Status
            };
        }
    }
}
