namespace Customers.Api.Contracts.Messages
{
    public class CustomerCreated
    {
        public required Guid Id { get; set; }

        public required string FullName { get; set; } = null!;

        public required string Email { get; set; } = null!;
        
        public required string GitHubUsername { get; set; } = null!;

        public required DateTime DateOfBirth { get; set; }
    }
    
    public class CustomerUpdated
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;
        
        public string GitHubUsername { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
    }

    public class CustomerDeleted
    {
        public Guid Id { get; set; }
    }
}