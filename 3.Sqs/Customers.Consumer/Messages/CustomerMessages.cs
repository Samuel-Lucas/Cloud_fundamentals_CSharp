namespace Customers.Consumer.Messages
{
    public class CustomerCreated : ISqsMessage
    {
        public required Guid Id { get; set; }

        public required string FullName { get; set; } = null!;

        public required string Email { get; set; } = null!;
        
        public required string GitHubUsername { get; set; } = null!;

        public required DateTime DateOfBirth { get; set; }
    }
    
    public class CustomerUpdated : ISqsMessage
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;
        
        public string GitHubUsername { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
    }

    public class CustomerDeleted : ISqsMessage
    {
        public Guid Id { get; set; }
    }
}