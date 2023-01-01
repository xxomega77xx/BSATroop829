using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BSATroop829.Models
{
    public class FileManagerViewModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? Path { get; set; }
        [StringLength(255)]
        public string? Type { get; set; }

        [NotMappedAttribute]
        [Required(ErrorMessage = "File is required.")]
        public List<IFormFile>? File { get; set; }
    }
}
