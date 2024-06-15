using Domain.AggregatesModel.UserModel;

namespace Domain.Infraestructure.Repositories;

public interface IUserRepository
{
    Task<int> Create(User User, CancellationToken cancellationToken = default);
    Task Update(User User, CancellationToken cancellationToken = default);
    Task<User> GetByIdAndType(int id, int type, CancellationToken cancellationToken = default);
    Task<List<User>> GetAll(CancellationToken cancellationToken = default);
    Task Delete(User user, CancellationToken cancellationToken = default);
    Task<User> GetById(int id, CancellationToken cancellationToken = default);
}
