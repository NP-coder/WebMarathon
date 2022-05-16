using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarathon.Models
{
    public class WorldMonument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пам'ятка")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Місто")]
        public string Town { get; set; }

        [Required]
        [Display(Name = "Країна")]
        public string Country { get; set; }

    }
}
