using DbP.Models;
using Microsoft.EntityFrameworkCore;

namespace DbP.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> student { get; set; }
    }
}
