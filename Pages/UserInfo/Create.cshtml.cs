using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SleepHack.Data;
using SleepHack.Models;

namespace SleepHack.Pages.UserInfo
{
    public class CreateModel : PageModel
    {
        private readonly SleepHack.Data.SleepHackContext _context;

        public CreateModel(SleepHack.Data.SleepHackContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sleep Sleep { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sleep.Add(Sleep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
