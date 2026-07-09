namespace Adapters.DTOs.HotelDTOs
{
    public class CreateHotelDTO
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int ManagerId { get; set; }
    }
}
