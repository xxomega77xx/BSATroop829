using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class MeritBadgeCounselorsViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? MeritBadgeName { get; set; }
        public string? CounselorName { get; set; }
        public string? CounselorPhoneNumber { get; set; }
    }
}
