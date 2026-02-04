using System;

namespace EMS.Data.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = null!;
        public decimal Budget { get; set; }
        public string DepartmentName { get; set; } = null!;
    }

    public class CreateProjectDto
    {
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateProjectDto
    {
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Budget { get; set; }
    }
}
