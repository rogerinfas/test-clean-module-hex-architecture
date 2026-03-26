using Auth.Module.Domain.Entities;
using Auth.Module.Domain.Ports;

namespace Auth.Module.Infrastructure.Adapters;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public Task<User?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Email == email));
    }

    public Task<User> AddAsync(User user)
    {
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task UpdateAsync(User user)
    {
        var index = _users.FindIndex(u => u.Id == user.Id);
        if (index >= 0) _users[index] = user;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null) _users.Remove(user);
        return Task.CompletedTask;
    }
}
