using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RAD_Lab5.Data;
using RAD_Lab5.Models;

namespace RAD_Lab5.Pages.FluentUsers
{
    public class EditModel : PageModel
    {
        private readonly RAD_Lab5.Data.Rad_Lab5FluentContext _context;

        public EditModel(RAD_Lab5.Data.Rad_Lab5FluentContext context)
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

            var fluentuser =  await _context.User.FirstOrDefaultAsync(m => m.UniqueIdentifier == id);
            if (fluentuser == null)
            {
                return NotFound();
            }
            FluentUser = fluentuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FluentUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FluentUserExists(FluentUser.UniqueIdentifier))
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

        private bool FluentUserExists(int id)
        {
            return _context.User.Any(e => e.UniqueIdentifier == id);
        }
    }
}
