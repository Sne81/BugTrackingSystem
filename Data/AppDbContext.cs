using Microsoft.EntityFrameworkCore;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial users (password: "admin123" and "member123" - hashed)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    FullName = "Admin User",
                    Email = "admin@bugtracker.com",
                    Role = "Admin",
                    CreatedDate = DateTime.Now
                },
                new User
                {
                    UserId = 2,
                    Username = "member",
                    Password = BCrypt.Net.BCrypt.HashPassword("member123"),
                    FullName = "Member User",
                    Email = "member@bugtracker.com",
                    Role = "Member",
                    CreatedDate = DateTime.Now
                }
            );

            // Seed initial bug data
            modelBuilder.Entity<Bug>().HasData(
                new Bug
                {
                    BugId = 1,
                    Title = "Login Issue",
                    Description = "Users cannot login with correct credentials",
                    Severity = "High",
                    Status = "Open",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
