using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SleepHack.Data;
using SleepHack.Models;

namespace SleepHack.Pages.UserInfo
{
    public class IndexModel : PageModel
    {
        private readonly SleepHack.Data.SleepHackContext _context;

        public IndexModel(SleepHack.Data.SleepHackContext context)
        {
            _context = context;
        }

        public IList<Sleep> Sleep { get;set; }

        public async Task OnGetAsync()
        {
            Sleep = await _context.Sleep.ToListAsync();
        }
    }
}
