using Domain.AggregatesModel.ProducerModel;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;

namespace Infraestructure.Repositories;

public class ProducerRepository(IEquiMarketContext context) : IProducerRepository
{
    private readonly IEquiMarketContext _context = context ?? throw new ArgumentNullException();

    public async Task<int> Create(Producer producer, CancellationToken cancellationToken = default)
    {
        await _context.Producers.AddAsync(producer, cancellationToken);
        await _context.CommitAsync(cancellationToken);
        return producer.Id;
    }
}
