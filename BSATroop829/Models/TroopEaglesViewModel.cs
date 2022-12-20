using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class TroopEaglesViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ScoutName { get; set; }
        [Required]
        public string? BoardofReviewDate { get; set; }
    }
}
