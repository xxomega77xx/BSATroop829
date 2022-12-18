using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class SummerCampViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ScoutName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Rank { get; set; }
        [Required]
        public string? MeritBadge { get; set; }
        [Required]
        public string? TimeSlot { get; set; }
        [Required]
        public string? Priority { get; set; }
        public bool EagleRequired  { get; set; }
        public string? Prerequisites { get; set; }
        
    }
}
