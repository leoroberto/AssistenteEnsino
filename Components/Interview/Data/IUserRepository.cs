using AssistenteDeEnsino.Components.Interview.Entities;

namespace AssistenteDeEnsino.Components.Interview.Data;

public interface IUserRepository
{
    Task AddAsync(User user);
}