namespace BudgetBackend.Models;

public class Income
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public required string Description { get; set; }
    
    public required User User { get; set; }
}