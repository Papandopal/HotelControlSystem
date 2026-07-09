namespace HotelControlSystem.DTOs.HotelDTOs
{
    public class HotelInfoConsoleDTO
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int ManagerId { get; init; }
        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Address: {Country}, {City}, {Address}\n" +
                   $"Rating: {Rating}\n" +
                   $"ManagerId: {ManagerId}";
        }
    }
}
