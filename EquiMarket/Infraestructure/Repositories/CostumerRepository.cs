using Domain.AggregatesModel.CostumerModel;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;

namespace Infraestructure.Repositories;

public class CostumerRepository(IEquiMarketContext context) : ICostumerRepository
{
    private readonly IEquiMarketContext _context = context ?? throw new ArgumentNullException();

    public async Task<int> Create(Costumer costumer, CancellationToken cancellationToken = default)
    {
        await _context.Costumers.AddAsync(costumer, cancellationToken);
        await _context.CommitAsync(cancellationToken);
        return costumer.Id;
    }
}
