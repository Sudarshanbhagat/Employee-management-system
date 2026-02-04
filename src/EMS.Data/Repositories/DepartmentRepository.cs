using EMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
    }

    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmsDbContext context) : base(context) { }
    }
}
