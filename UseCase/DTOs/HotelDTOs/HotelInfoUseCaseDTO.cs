namespace UseCase.DTOs.HotelDTOs
{
    public class HotelInfoUseCaseDTO
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int ManagerId { get; init; }
    }
}
