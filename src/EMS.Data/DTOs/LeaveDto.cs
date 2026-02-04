using System;

namespace EMS.Data.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = null!;
        public string Status { get; set; } = null!;
    }

    public class CreateLeaveRequestDto
    {
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = null!;
    }

    public class ApproveLeaveDto
    {
        public bool IsApproved { get; set; }
        public string Comments { get; set; } = string.Empty;
    }
}
