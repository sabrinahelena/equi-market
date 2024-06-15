using Domain.AggregatesModel.ProducerModel;

namespace Domain.Infraestructure.Repositories;

public interface IProducerRepository
{
    Task<int> Create(Producer producer, CancellationToken cancellationToken = default);
}
