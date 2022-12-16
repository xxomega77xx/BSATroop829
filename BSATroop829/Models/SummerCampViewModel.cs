using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class SummerCampViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ScoutName { get; set; }
        public string? MeritBadge { get; set; }
        public string? TimeofDay { get; set; }
        public bool EagleRequired  { get; set; }
        public string? Prerequisites { get; set; }
        public string? Priority { get; set; }
    }
}
