using Domain.AggregatesModel.Common;

namespace Domain.Infraestructure.Repositories;

public interface IReviewRepository
{
    Task<int> Create(Review review, CancellationToken cancellationToken = default);
    Task Update(Review review, CancellationToken cancellationToken = default);
    Task<Review> GetById(int id, CancellationToken cancellationToken = default);
    Task<List<Review>> GetAll(CancellationToken cancellationToken = default);
    Task<List<Review>> GetAllByProductId(int productId, CancellationToken cancellationToken = default);
    Task<List<Review>> GetAllByCostumerId(int costumerId, CancellationToken cancellationToken = default);

}
