using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SleepHack.Models;

namespace SleepHack.Data
{
    public class SleepHackContext : DbContext
    {
        public SleepHackContext (DbContextOptions<SleepHackContext> options)
            : base(options)
        {
        }

        public DbSet<SleepHack.Models.Sleep> Sleep { get; set; }
    }
}
