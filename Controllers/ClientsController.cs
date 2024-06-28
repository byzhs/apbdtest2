using APBDTEST2.DTOs;
using APBDTEST2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDTEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public ClientsController(IDbService dbService) {
            _dbService = dbService;
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient(int clientId) {
            var client = await _dbService.GetClientByIdAsync(clientId);
            if (client == null)
                return NotFound($"Client with ID {clientId} not found");

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientWithRental(NewClientDTO newClientDTO) {
            if (!await _dbService.DoesCarExistAsync(newClientDTO.CarRental.CarId))
                return NotFound($"Car with ID {newClientDTO.CarRental.CarId} not found");

            try
            {
                await _dbService.AddClientWithRentalAsync(newClientDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}