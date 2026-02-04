namespace EMS.Data.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string TableName { get; set; } = null!;
        public int RecordId { get; set; }
        public string Action { get; set; } = null!;
        public int ChangedByEmployeeId { get; set; }
        public string ChangeDetails { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }

        // Navigation properties
        public Employee? ChangedByEmployee { get; set; }
    }
}
