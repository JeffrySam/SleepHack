using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SleepHack.Data;
using SleepHack.Models;

namespace SleepHack.Pages.UserInfo
{
    public class EditModel : PageModel
    {
        private readonly SleepHack.Data.SleepHackContext _context;

        public EditModel(SleepHack.Data.SleepHackContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sleep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SleepExists(Sleep.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SleepExists(int id)
        {
            return _context.Sleep.Any(e => e.ID == id);
        }
    }
}
