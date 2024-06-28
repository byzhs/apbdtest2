namespace APBDTEST2.DTOs
{
    public class ClientDTO {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ICollection<CarRentalDTO> Rentals { get; set; } = new List<CarRentalDTO>();
    }

    public class NewClientDTO {
        public ClientDataDTO Client { get; set; } = new ClientDataDTO();
        public NewCarRentalDTO CarRental { get; set; } = new NewCarRentalDTO();
    }

    public class ClientDataDTO {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}