using EMS.Data.DTOs;

namespace EMS.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto?> GetProjectByIdAsync(int id);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
        Task<IEnumerable<ProjectDto>> GetProjectsByDepartmentAsync(int departmentId);
        Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto);
        Task<bool> UpdateProjectAsync(int id, UpdateProjectDto dto);
        Task<bool> DeleteProjectAsync(int id);
    }
}
