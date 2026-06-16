using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMain.Entities
{
    public class Hotel
    {
        private Hotel() {} 
        public Hotel(User manager) 
        {
            Manager = manager;
        }
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Rating
        {
            get
            {
                var randomizer = new Random();
                int rating = randomizer.Next();
                return rating;
            }
        }

        public int ManagerId { get; set; }
        public User Manager { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
