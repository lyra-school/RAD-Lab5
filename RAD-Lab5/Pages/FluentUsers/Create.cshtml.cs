using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAD_Lab5.Data;
using RAD_Lab5.Models;

namespace RAD_Lab5.Pages.FluentUsers
{
    public class CreateModel : PageModel
    {
        private readonly RAD_Lab5.Data.Rad_Lab5FluentContext _context;

        public CreateModel(RAD_Lab5.Data.Rad_Lab5FluentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FluentUser FluentUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(FluentUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
