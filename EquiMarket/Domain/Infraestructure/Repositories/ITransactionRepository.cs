using Domain.AggregatesModel.Common;

namespace Domain.Infraestructure.Repositories;

public interface ITransactionRepository
{
    Task<int> Create(Transaction transaction, CancellationToken cancellationToken = default);
    Task Update(Transaction transaction, CancellationToken cancellationToken = default);
    Task<Transaction> GetById(int id, CancellationToken cancellationToken = default);
    Task<Transaction> GetByProductId(int productId, CancellationToken cancellationToken = default);
    Task<List<Transaction>> GetAllByCostumerId(int costumerId, CancellationToken cancellationToken = default);
}
