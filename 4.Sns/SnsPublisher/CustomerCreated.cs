namespace SnsPublisher
{
    public class CustomerCreated
    {
        public required Guid Id { get; set; }

        public required string FullName { get; set; } = null!;

        public required string Email { get; set; } = null!;
        
        public required string GitHubUsername { get; set; } = null!;

        public required DateTime DateOfBirth { get; set; }
    }
}