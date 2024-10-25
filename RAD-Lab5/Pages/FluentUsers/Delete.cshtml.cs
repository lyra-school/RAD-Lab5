using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAD_Lab5.Data;
using RAD_Lab5.Models;

namespace RAD_Lab5.Pages.FluentUsers
{
    public class DeleteModel : PageModel
    {
        private readonly RAD_Lab5.Data.Rad_Lab5FluentContext _context;

        public DeleteModel(RAD_Lab5.Data.Rad_Lab5FluentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FluentUser FluentUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentuser = await _context.User.FirstOrDefaultAsync(m => m.UniqueIdentifier == id);

            if (fluentuser == null)
            {
                return NotFound();
            }
            else
            {
                FluentUser = fluentuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentuser = await _context.User.FindAsync(id);
            if (fluentuser != null)
            {
                FluentUser = fluentuser;
                _context.User.Remove(FluentUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
