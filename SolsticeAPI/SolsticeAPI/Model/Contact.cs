using System;
using System.ComponentModel.DataAnnotations;

namespace SolsticeAPI.Model
{
    public class Contact
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public Address Address{ get; set; }
        [Required]
        public Company Company { get; set; }
        public string ProfileImage { get; set; }
    }
}
