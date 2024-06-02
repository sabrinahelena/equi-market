using Domain.AggregatesModel.Common;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infraestructure.Repositories;

public class ReviewRepository(IEquiMarketContext context) : IReviewRepository
{
    private readonly IEquiMarketContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<int> Create(Review review, CancellationToken cancellationToken = default)
    {
        await _context.Reviews.AddAsync(review, cancellationToken);
        await _context.CommitAsync(cancellationToken);

        return review.Id;
    }

    public async Task<List<Review>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _context.Reviews.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<List<Review>> GetAllByCostumerId(int costumerId, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews.Where(x => x.CostumerId == costumerId).ToListAsync(cancellationToken);
    }

    public async Task<List<Review>> GetAllByProductId(int productId, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews.Where(x => x.ProductId == productId).ToListAsync(cancellationToken);
    }

    public async Task<Review> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews.Where(x => x.Id == id).FirstAsync(cancellationToken);
    }

    public async Task Update(Review review, CancellationToken cancellationToken = default)
    {
        _context.AttachAndUpdate(review);
        await _context.CommitAsync(cancellationToken);
    }
}
