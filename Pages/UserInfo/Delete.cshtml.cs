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
    public class DeleteModel : PageModel
    {
        private readonly SleepHack.Data.SleepHackContext _context;

        public DeleteModel(SleepHack.Data.SleepHackContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sleep = await _context.Sleep.FindAsync(id);

            if (Sleep != null)
            {
                _context.Sleep.Remove(Sleep);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
