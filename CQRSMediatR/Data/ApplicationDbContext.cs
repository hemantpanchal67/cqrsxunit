using CQRSMediatR.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
