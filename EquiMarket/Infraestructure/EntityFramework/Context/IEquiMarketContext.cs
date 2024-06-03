using Domain.AggregatesModel.Common;
using Domain.AggregatesModel.CostumerModel;
using Domain.AggregatesModel.ProducerModel;
using Domain.AggregatesModel.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.EntityFramework.Context;

public interface IEquiMarketContext
{
    DbSet<User> Users { get; }
    DbSet<Costumer> Costumers { get; }
    DbSet<Producer> Producers { get; }
    DbSet<Product> Products { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<Review> Reviews { get; }
    void AttachAndUpdate<TEntity>(TEntity entity) where TEntity : class;
    public Task<bool> CommitAsync(CancellationToken cancellationToken = default);
}
