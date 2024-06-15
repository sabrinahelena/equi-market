using Domain.AggregatesModel.UserModel;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class UserRepository(IEquiMarketContext context) : IUserRepository
{
    private readonly IEquiMarketContext _context = context ?? throw new ArgumentNullException();
    public async Task<int> Create(User User, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(User, cancellationToken);
        await _context.CommitAsync(cancellationToken);
        return User.Id;
    }

    public async Task Delete(User user, CancellationToken cancellationToken = default)
    {
       _context.Users.Remove(user);
       await _context.CommitAsync(cancellationToken);
    }

    public Task<List<User>> GetAll(CancellationToken cancellationToken = default)
    {
        return _context.Users.ToListAsync(cancellationToken);
    }

    public Task<User> GetByIdAndType(int id, int type, CancellationToken cancellationToken = default)
    {
        return _context.Users.Where(x => x.Id == id && x.Type == type).FirstAsync(cancellationToken);
    }

    public Task<User> GetById(int id, CancellationToken cancellationToken = default)
    {
        return _context.Users.Where(x => x.Id == id).FirstAsync(cancellationToken);
    }

    public async Task Update(User user, CancellationToken cancellationToken = default)
    {
        _context.AttachAndUpdate(user);
        await _context.CommitAsync(cancellationToken);
    }
}
