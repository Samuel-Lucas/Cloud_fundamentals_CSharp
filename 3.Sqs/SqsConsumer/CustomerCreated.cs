namespace SqsConsumer;

public class CustomerCreated
{
    public Guid Id { get; init; }
    
    public string FullName { get; init; } = null!;

    public string Email { get; init; } = null!;
    
    public string GitHubUsername { get; init; } = null!;

    public DateTime DateOfBirth { get; init; }
}
