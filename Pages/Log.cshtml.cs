using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SleepHack.Pages
{
    public class LogModel : PageModel
    {
        [BindProperty]
        public DateTime sleep { get; set; }

        [BindProperty]
        public int sleeprate { get; set; }
        
        [BindProperty]
        public string sleepnotes { get; set; }

        [BindProperty]
        public DateTime wake { get; set; }
        
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("/Index");
            
        }
    }
}