using Microsoft.EntityFrameworkCore;

namespace SleepHack.Data
{
    public class SleepHackContext : DbContext
    {
        public SleepHackContext (
            DbContextOptions<SleepHackContext> options)
            : base(options)
        { }

        public DbSet<>
    }
}
