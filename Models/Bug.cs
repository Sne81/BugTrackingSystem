using System;
using System.ComponentModel.DataAnnotations;

namespace BugTrackingSystem.Models
{
    public class Bug
    {
        [Key]
        public int BugId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Severity { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
    }
}
