using System;
using System.ComponentModel.DataAnnotations;

namespace SolsticeAPI.Model
{
    public class City
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        //public int StateId { get; set; }
        public State State { get; set; }
    }
}
