using BudgetBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetBackend.Repositories;

public class UserRepository : IUserRepository
{
    private BudgetContext _context;
    
    public UserRepository(BudgetContext context)
    {
        this._context = context;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _context.Users.SingleAsync(b => b.Id == userId, cancellationToken);
        
        return result;
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var result = await _context.Users.SingleAsync(b => b.Email == email, cancellationToken);
        
        return result;
    }

    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
    }

    public async Task UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        //await context.Users.async(user, cancellationToken);
    }
}