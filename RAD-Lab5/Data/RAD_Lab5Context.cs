using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAD_Lab5.Models;

namespace RAD_Lab5.Data
{
    public class RAD_Lab5Context : DbContext
    {
        public RAD_Lab5Context (DbContextOptions<RAD_Lab5Context> options)
            : base(options)
        {
        }

        public DbSet<RAD_Lab5.Models.User> User { get; set; } = default!;
    }
}
