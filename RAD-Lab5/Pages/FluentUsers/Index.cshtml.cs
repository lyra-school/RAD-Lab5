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
    public class IndexModel : PageModel
    {
        private readonly RAD_Lab5.Data.Rad_Lab5FluentContext _context;

        public IndexModel(RAD_Lab5.Data.Rad_Lab5FluentContext context)
        {
            _context = context;
        }

        public IList<FluentUser> FluentUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FluentUser = await _context.User.ToListAsync();
        }
    }
}
