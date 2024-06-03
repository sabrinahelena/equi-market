using Domain.AggregatesModel.Common;
using Domain.AggregatesModel.CostumerModel;
using Domain.Infraestructure.Repositories;
using Infraestructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infraestructure.Repositories;

public class TransactionRepository(IEquiMarketContext context) : ITransactionRepository
{
    private readonly IEquiMarketContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<int> Create(Transaction transaction, CancellationToken cancellationToken = default)
    {
        await _context.Transactions.AddAsync(transaction, cancellationToken);
        await _context.CommitAsync(cancellationToken);
        return transaction.Id;
    }

    public async Task<List<Transaction>> GetAllByCostumerId(int costumerId, CancellationToken cancellationToken = default)
    {
        return await _context.Transactions.AsNoTracking().Where(x => x.CostumerId == costumerId).ToListAsync(cancellationToken);
    }

    public async Task<Transaction> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Transactions.AsNoTracking().Where(x => x.Id == id).FirstAsync(cancellationToken);
    }

    public async Task<Transaction> GetByProductId(int productId, CancellationToken cancellationToken = default)
    {
        return await _context.Transactions.AsNoTracking().Where(x => x.ProductId == productId).FirstAsync(cancellationToken);
    }

    public async Task Update(Transaction transaction, CancellationToken cancellationToken = default)
    {
        _context.AttachAndUpdate(transaction);
        await _context.CommitAsync(cancellationToken);
    }
}
