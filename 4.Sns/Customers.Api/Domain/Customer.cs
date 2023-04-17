namespace Customers.Api.Domain;

public class Customer
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string GitHubUsername { get; init; } = null!;

    public string FullName { get; init; } = null!;

    public string Email { get; init; } = null!;

    public DateTime DateOfBirth { get; init; }
}
