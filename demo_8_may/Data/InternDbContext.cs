using demo_8_may.Model;
using Microsoft.EntityFrameworkCore;

namespace demo_8_may.Data
{
    public class InternDbContext:DbContext
    {
        public InternDbContext(DbContextOptions<InternDbContext> options): base(options) { }
        public DbSet<Intern> Interns { get; set; }
    }
}
