using System.ComponentModel.DataAnnotations;


namespace JrJobFinder.Models.DTOs
{
    public class CreateJobOfferDTO
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(150)]
        public string Company { get; set; } = null!;
        [Required]
        public string Technologies { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string ExperienceLevel { get; set; } = null!;
        [MaxLength(150)]
        public string? Location { get; set; }
        public bool IsRemote { get; set; }
        [MaxLength(100)]
        public string? Source { get; set; }
    }
}
