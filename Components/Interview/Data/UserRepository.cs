using AssistenteDeEnsino.Components.Interview.Entities;
using AssistenteDeEnsino.Data;

namespace AssistenteDeEnsino.Components.Interview.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}