using LabDb.Models;
using Microsoft.EntityFrameworkCore;

namespace LabDb.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> student { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Rider> rider { get; set; }
    }
}
