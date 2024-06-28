using APBDTEST2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, VIN = "2D4HN11EX9R686008", Name = "Toyota", Seats = 5, PricePerDay = 120, ModelId = 1, ColorId = 1 },
                new Car { Id = 2, VIN = "JTDBR32E630013672", Name = "Skoda", Seats = 5, PricePerDay = 170, ModelId = 2, ColorId = 2 }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "Jan", LastName = "Kowalski", Address = "Koszykowa 86" },
                new Client { Id = 2, FirstName = "John", LastName = "Yakuza", Address = "Tenkaichi Street" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, Name = "Toyota" },
                new Model { Id = 2, Name = "Skoda" }
            );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "White" },
                new Color { Id = 2, Name = "Black" }
            );

            modelBuilder.Entity<CarRental>().HasData(
                new CarRental { Id = 1, ClientId = 1, CarId = 1, DateFrom = new DateTime(2024, 6, 24), DateTo = new DateTime(2024, 6, 28), TotalPrice = 480, Discount = 0 },
                new CarRental { Id = 2, ClientId = 1, CarId = 1, DateFrom = new DateTime(2024, 7, 1), DateTo = new DateTime(2024, 7, 5), TotalPrice = 240, Discount = 0 },
                new CarRental { Id = 3, ClientId = 1, CarId = 2, DateFrom = new DateTime(2024, 8, 1), DateTo = new DateTime(2024, 8, 10), TotalPrice = 1700, Discount = 0 }
            );
        }
    }
}
