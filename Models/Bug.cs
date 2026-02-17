using System.ComponentModel.DataAnnotations;

namespace BugTrackingSystem.Models
{
    public class Bug
    {
        [Key]
        public int BugId { get; set; }

        [Required(ErrorMessage = "Bug title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Severity { get; set; } = "Low";

        [Required]
        public string Status { get; set; } = "Open";

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
    }
}
