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
        
        public string? MeritBadge { get; set; }
        
        public string? TimeSlot { get; set; }
        [Required]
        public string? Priority1 { get; set; }
        [Required]
        public string? Priority2 { get; set; }
        [Required]
        public string? Priority3 { get; set; }
        [Required]
        public string? Priority4 { get; set; }
        [Required]
        public string? Priority5 { get; set; }
        [Required]
        public string? Priority6 { get; set; }
        [Required]
        public string? Priority7 { get; set; }
        [Required]
        public string? Priority8 { get; set; }
        [Required]
        public string? Priority9 { get; set; }
        [Required]
        public string? Priority10 { get; set; }
        [Required]
        public string? Priority11{ get; set; }
        [Required]
        public string? Priority12{ get; set; }
        public bool EagleRequired { get; set; }
        public string? Prerequisites { get; set; }

    }
}
