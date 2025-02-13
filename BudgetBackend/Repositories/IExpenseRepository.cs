using BudgetBackend.Models;

namespace BudgetBackend.Repositories;

public interface IExpenseRepository
{
    Task<Expense?> GetExpenseByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Expense>?> GetExpenseByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task AddExpenseAsync(Expense expense, CancellationToken cancellationToken);
    Task UpdateExpenseAsync(Expense expense, CancellationToken cancellationToken);
    Task DeleteExpenseByIdAsync(Guid id, CancellationToken cancellationToken);
}