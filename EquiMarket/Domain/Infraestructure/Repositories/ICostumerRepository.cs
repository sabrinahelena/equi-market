using Domain.AggregatesModel.CostumerModel;

namespace Domain.Infraestructure.Repositories;

public interface ICostumerRepository
{
    Task<int> Create(Costumer costumer, CancellationToken cancellationToken = default);
}
