using EMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Repositories
{
    public interface ILeaveRequestRepository : IRepository<LeaveRequest>
    {
        Task<IEnumerable<LeaveRequest>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<LeaveRequest>> GetPendingAsync();
    }

    public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(EmsDbContext context) : base(context) { }

        public async Task<IEnumerable<LeaveRequest>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Where(l => l.EmployeeId == employeeId)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetPendingAsync()
        {
            return await _dbSet
                .Where(l => l.Status == "Pending")
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .ToListAsync();
        }

        public override async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
