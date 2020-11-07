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
    public class DetailsModel : PageModel
    {
        private readonly SleepHack.Data.SleepHackContext _context;

        public DetailsModel(SleepHack.Data.SleepHackContext context)
        {
            _context = context;
        }

        public Sleep Sleep { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sleep = await _context.Sleep.FirstOrDefaultAsync(m => m.ID == id);

            if (Sleep == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
