using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarathon.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Клієнт")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Туристична пам'ятка")]
        public int MonumentId { get; set; }
        public WorldMonument Monument { get; set; }

        [Required]
        [Display(Name = "Дата подорожі")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Статус")]
        public string Status { get; set; }
    }
}
