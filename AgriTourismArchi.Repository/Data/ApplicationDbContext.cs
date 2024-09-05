using AgriTourismArchi.Aggregator.Models; // Correct namespace for Category
using Microsoft.EntityFrameworkCore;

namespace AgriTourismArchi.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Categories table will be created
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // Payment and User tables
        public DbSet<User> Users { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Farm Stay",
                    Location = "Countryside",
                    Cost = 100.00,
                    Capacity = 10,
                    Date = new DateTime(2024, 1, 15)
                },
                new Category
                {
                    Id = 2,
                    Name = "Vineyard Tour",
                    Location = "Wine Country",
                    Cost = 150.00,
                    Capacity = 20,
                    Date = new DateTime(2024, 2, 20)
                }
            );

            // Seed data for the User table
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "1234567890", Address = "123 Main St" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "0987654321", Address = "456 Elm St" }
            );

            // Seed data for the Payment table
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    CategoryId = 1,
                    UserId = 1,
                    PlaceName = "Green Park",
                    Location = "Downtown",
                    Date = new DateTime(2024, 9, 15),
                    Name = "John Doe",
                    Number = "12345"
                },
                new Payment
                {
                    Id = 2,
                    CategoryId = 2,
                    UserId = 2,
                    PlaceName = "Blue Lake",
                    Location = "Uptown",
                    Date = new DateTime(2024, 9, 16),
                    Name = "Jane Smith",
                    Number = "67890"
                }
            );
        }
    }
}
