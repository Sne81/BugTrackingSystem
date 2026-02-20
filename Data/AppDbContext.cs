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

    modelBuilder.Entity<User>().HasData(
        new User
        {
            UserId = 1,
            Username = "admin",
            Password = "$2a$11$7b6J8v5u6zq8r9p0J1KfEODd8x7y6R1JYhP1k9ZqQhT5C8eW1R3uK", // pre-generated hash
            FullName = "Admin User",
            Email = "admin@bugtracker.com",
            Role = "Admin",
            CreatedDate = new DateTime(2024,1,1)
        },
        new User
        {
            UserId = 2,
            Username = "member",
            Password = "$2a$11$7b6J8v5u6zq8r9p0J1KfEODd8x7y6R1JYhP1k9ZqQhT5C8eW1R3uK",
            FullName = "Member User",
            Email = "member@bugtracker.com",
            Role = "Member",
            CreatedDate = new DateTime(2024,1,1)
        }
    );

    modelBuilder.Entity<Bug>().HasData(
        new Bug
        {
            BugId = 1,
            Title = "Login Issue",
            Description = "Users cannot login with correct credentials",
            Severity = "High",
            Status = "Open",
            Comment = "Initial bug record",
            CreatedDate = new DateTime(2024,1,1),
            UpdatedDate = new DateTime(2024,1,1)
        }
    );
}
    }
}
