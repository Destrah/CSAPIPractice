using System.ComponentModel.DataAnnotations;

namespace CSAPIPractice.DTOs
{
    public record AddPlayerDTO
    {
        [Required]
        public string Identifier { get; init; }
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string Job { get; init; }
        [Required]
        public bool JobDuty { get; init; }
        [Required]
        public bool ToggleStatus { get; set; }
        [Required]
        public int Rank { get; set; }
    }
}