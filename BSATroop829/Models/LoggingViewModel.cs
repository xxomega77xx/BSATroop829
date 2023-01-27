using System;
using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class LoggingViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? User { get; set; }
        [Required]
        public string? Action { get; set; }
        [Required]
        public DateTime? TimeStamp { get; set; }
    }
}
