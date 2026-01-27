using Microsoft.EntityFrameworkCore;

namespace Employee.Api.Infrastructure.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
          : base(options)
        {
        }

    }
}
