using BudgetBackend.Models;

namespace BudgetBackend.Repositories;

public interface IIncomeRepositories
{
    Task<Income?> GetIncomeByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Income>?> GetIncomesByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task AddIncomeAsync(Income income, CancellationToken cancellationToken);
    Task UpdateIncomeAsync(Income income, CancellationToken cancellationToken);
    Task DeleteIncomeByIdAsync(Guid id, CancellationToken cancellationToken);
}