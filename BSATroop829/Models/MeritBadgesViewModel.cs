using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class MeritBadgesViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(3)]
        public string? Eagle_Required { get; set; }
        [Required]
        [StringLength(255)]
        public string? Requirements { get; set; }

    }
}
