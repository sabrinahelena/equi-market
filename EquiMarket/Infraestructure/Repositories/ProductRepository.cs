using Domain.AggregatesModel.Common;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class ProductRepository(IEquiMarketContext context) : IProductRepository
{
    private readonly IEquiMarketContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<int> Create(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.CommitAsync(cancellationToken);
        return product.Id;
    }

    public async Task Delete(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Remove(product);
        await _context.CommitAsync(cancellationToken);

    }

    public async Task<List<Product>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<List<Product>> GetAllByProducerId(int producerId, CancellationToken cancellationToken = default)
    {
        return await _context.Products.AsNoTracking().Where(x => x.ProducerId == producerId).ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        _context.AttachAndUpdate(product);
        await _context.CommitAsync(cancellationToken);
    }
}
