namespace EMS.Data.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public List<Employee> Employees { get; set; } = new();
    }
}
