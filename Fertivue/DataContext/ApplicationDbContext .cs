using Fertivue.Modal;
using Microsoft.EntityFrameworkCore;

namespace Fertivue.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Users> User { get; set; }
    }
}
