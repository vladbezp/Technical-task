using Microsoft.EntityFrameworkCore;
using Technical_task.Models;

namespace Technical_task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<QA> QA { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
