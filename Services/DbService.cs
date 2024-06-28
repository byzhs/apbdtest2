using APBDTEST2.Data;
using APBDTEST2.DTOs;
using APBDTEST2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseContext _context;

        public DbService(DatabaseContext context) {
            _context = context;
        }

        public async Task<ClientDTO> GetClientByIdAsync(int clientId) {
            var client = await _context.Clients
                .Include(c => c.CarRentals)
                .ThenInclude(cr => cr.Car)
                .ThenInclude(c => c.Color)
                .Include(c => c.CarRentals)
                .ThenInclude(cr => cr.Car)
                .ThenInclude(c => c.Model)
                .FirstOrDefaultAsync(c => c.Id == clientId);

            if (client == null)
                return null;

            return new ClientDTO {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Rentals = client.CarRentals.Select(cr => new CarRentalDTO {
                    VIN = cr.Car.VIN,
                    Color = cr.Car.Color.Name,
                    Model = cr.Car.Model.Name,
                    DateFrom = cr.DateFrom,
                    DateTo = cr.DateTo,
                    TotalPrice = cr.TotalPrice
                }).ToList()
            };
        }

        public async Task AddClientWithRentalAsync(NewClientDTO newClientDTO) {
            var client = new Client {
                FirstName = newClientDTO.Client.FirstName,
                LastName = newClientDTO.Client.LastName,
                Address = newClientDTO.Client.Address
            };

            var car = await _context.Cars.FindAsync(newClientDTO.CarRental.CarId);

            if (car == null)
                throw new Exception($"Car with ID {newClientDTO.CarRental.CarId} does not exist");

            var totalPrice = (newClientDTO.CarRental.DateTo - newClientDTO.CarRental.DateFrom).Days * car.PricePerDay;

            var rental = new CarRental {
                Client = client,
                CarId = newClientDTO.CarRental.CarId,
                DateFrom = newClientDTO.CarRental.DateFrom,
                DateTo = newClientDTO.CarRental.DateTo,
                TotalPrice = totalPrice,
                Discount = 0
            };

            await _context.Clients.AddAsync(client);
            await _context.CarRentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesCarExistAsync(int carId)
        {
            return await _context.Cars.AnyAsync(c => c.Id == carId);
        }
    }
}
