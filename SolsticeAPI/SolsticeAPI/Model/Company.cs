using System;
using System.ComponentModel.DataAnnotations;

namespace SolsticeAPI.Model
{
    public class Company
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
