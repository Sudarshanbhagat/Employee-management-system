using EMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetByDepartmentAsync(int departmentId);
    }

    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(EmsDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> GetByDepartmentAsync(int departmentId)
        {
            return await _dbSet
                .Where(p => p.DepartmentId == departmentId)
                .Include(p => p.Department)
                .ToListAsync();
        }

        public override async Task<Project?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Department)
                .Include(p => p.CreatedBy)
                .Include(p => p.Employees)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
