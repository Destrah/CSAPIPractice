namespace CSAPIPractice.DTOs
{
    public record PlayerDTO
    {
        public string Identifier { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Job { get; init; }
    }
}