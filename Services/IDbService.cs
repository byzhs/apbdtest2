using APBDTEST2.DTOs;
using APBDTEST2.Models;

namespace APBDTEST2.Services
{
    public interface IDbService {
        Task<ClientDTO> GetClientByIdAsync(int clientId);
        Task AddClientWithRentalAsync(NewClientDTO newClientDTO);
        Task<bool> DoesCarExistAsync(int carId);
    }
}