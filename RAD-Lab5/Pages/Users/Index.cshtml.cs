using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAD_Lab5.Data;
using RAD_Lab5.Models;

namespace RAD_Lab5.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RAD_Lab5.Data.RAD_Lab5Context _context;

        public IndexModel(RAD_Lab5.Data.RAD_Lab5Context context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
