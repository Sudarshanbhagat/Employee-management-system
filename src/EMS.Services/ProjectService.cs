using EMS.Data.DTOs;
using EMS.Data.Models;
using EMS.Data.Repositories;
using EMS.Services.Interfaces;
using EMS.Common.Exceptions;

namespace EMS.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return null;

            return MapToDto(project);
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Select(MapToDto).ToList();
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsByDepartmentAsync(int departmentId)
        {
            var projects = await _projectRepository.GetByDepartmentAsync(departmentId);
            return projects.Select(MapToDto).ToList();
        }

        public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                ProjectName = dto.ProjectName,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Budget = dto.Budget,
                DepartmentId = dto.DepartmentId,
                Status = "Planning",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _projectRepository.CreateAsync(project);
            return MapToDto(project);
        }

        public async Task<bool> UpdateProjectAsync(int id, UpdateProjectDto dto)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                throw new NotFoundException($"Project with id {id} not found");

            project.ProjectName = dto.ProjectName;
            project.Description = dto.Description;
            project.Status = dto.Status;
            project.Budget = dto.Budget;
            project.UpdatedAt = DateTime.UtcNow;

            await _projectRepository.UpdateAsync(project);
            return true;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
            return true;
        }

        private static ProjectDto MapToDto(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status,
                Budget = project.Budget,
                DepartmentName = project.Department?.Name ?? string.Empty
            };
        }
    }
}
