using System;
using System.ComponentModel.DataAnnotations;

namespace SolsticeAPI.Model
{
    public class Address
    {
        public Guid ID{ get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        //public int CityId { get; set; }
        public City City{ get; set; }
    }
}
