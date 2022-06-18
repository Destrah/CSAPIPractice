using System.ComponentModel.DataAnnotations;

namespace CSAPIPractice.DTOs
{
    public record UpdatePlayerDTO
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string Job { get; init; }
    }
}