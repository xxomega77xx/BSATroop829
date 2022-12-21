using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSATroop829.Models
{
    public class PhotoGalleryVeiwModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? Path { get; set; }
        public int? NoOfViews { get; set; }

        [NotMappedAttribute]
        [Required(ErrorMessage = "Photo is required.")]
        public List<IFormFile>? PhotoFile { get; set; }
    }
}
