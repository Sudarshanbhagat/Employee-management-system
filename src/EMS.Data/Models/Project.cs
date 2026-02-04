namespace EMS.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Planning";
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
        public int CreatedByEmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Department? Department { get; set; }
        public Employee? CreatedBy { get; set; }
        public List<Employee> Employees { get; set; } = new();
    }
}
