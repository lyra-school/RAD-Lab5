using Microsoft.EntityFrameworkCore;
using RAD_Lab5.Models;

namespace RAD_Lab5.Data
{
    public class Rad_Lab5FluentContext : DbContext
    {
        public Rad_Lab5FluentContext() { }
        public Rad_Lab5FluentContext(DbContextOptions<Rad_Lab5FluentContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FluentUser");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FluentUser>().HasKey(t => t.UniqueIdentifier);
            modelBuilder.Entity<FluentUser>().Property(t => t.FirstName).HasMaxLength(50);
            modelBuilder.Entity<FluentUser>().Property(t => t.LastName).HasMaxLength(40);
            modelBuilder.Entity<FluentUser>().Property(t => t.Title).HasJsonPropertyName("Title");
            modelBuilder.Entity<FluentUser>().Property(t => t.Biography).HasMaxLength(256);
            modelBuilder.Entity<FluentUser>().Property(t => t.Age).HasColumnName("user_age");
            modelBuilder.Entity<FluentUser>().ToTable("FluentUser"
                /*, entity =>
                {
                entity.HasCheckConstraint(
                    "CK_FirstName", "DATALENGTH([FirstName]) >= 5"
                    );

                entity.HasCheckConstraint(
                    "CK_LastName", "DATALENGTH([LastName]) >= 4"
                    );

                entity.HasCheckConstraint(
                    "CK_Biography", "DATALENGTH([Biography]) >= 100"
                    );} */
            ).SplitToTable("Biography", table =>
            {
                table.Property(t => t.UniqueIdentifier);
                table.Property(t => t.Title);
                table.Property(t => t.Biography);
            }) ;
        }

        public DbSet<RAD_Lab5.Models.FluentUser> User { get; set; } = default!;
    }
}
