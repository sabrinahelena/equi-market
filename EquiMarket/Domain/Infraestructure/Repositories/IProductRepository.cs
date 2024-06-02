using Domain.AggregatesModel.Common;

namespace Domain.Infraestructure.Repositories;

public interface IProductRepository
{
    Task<int> Create(Product product, CancellationToken cancellationToken = default);
    Task Update(Product product, CancellationToken cancellationToken = default);  
    Task<Product> GetById(int id, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAllByProducerId(int producerId, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAll(CancellationToken cancellationToken = default);
    Task Delete(Product product, CancellationToken cancellationToken = default);

}
