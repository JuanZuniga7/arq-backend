using arq_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace arq_backend
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "Administrator" },
                new Role { Id = 2, Name = "Teacher", Description = "Teacher" },
                new Role { Id = 3, Name = "Student", Description = "Student" }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "admin@email.com", Password = "12345678", RoleId = 1 }
            );
        }

        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;

    }
}
