using BudgetBackend.Models;
using BudgetBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;
    
    public UserController(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    [HttpGet("byId")]
    public async Task<ActionResult<User>> GetUserByIdAsync(string userId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(Guid.Parse(userId), cancellationToken);
        return Ok(user);
    }
}