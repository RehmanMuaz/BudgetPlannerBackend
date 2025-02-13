namespace BudgetBackend.Models;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }

    public User()
    {
    }


    public User(Guid userId, string firstName, string lastName, string email)
    {
        this.Id = userId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
    }
}