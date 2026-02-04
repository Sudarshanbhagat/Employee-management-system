namespace EMS.Data.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DaysAllowed { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public List<LeaveRequest> LeaveRequests { get; set; } = new();
    }
}
