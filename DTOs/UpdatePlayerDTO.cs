using System.ComponentModel.DataAnnotations;

namespace CSAPIPractice.DTOs
{
    public record UpdatePlayerDTO
    {
        [Required]
        public string Job { get; init; }
        public bool JobDuty { get; init; }
        public int Rank { get; init; }
        public bool ToggleStatus { get; init; }
    }
}