using Domain.AggregatesModel.Common;
using Domain.AggregatesModel.CostumerModel;
using Domain.AggregatesModel.ProducerModel;
using Domain.AggregatesModel.UserModel;
using Domain.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure.EntityFramework.Context;

public class EquiMarketContext : DbContext, IEquiMarketContext
{
    public EquiMarketContext(DbContextOptions<EquiMarketContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This method is intentionally left blank, you can add your own debug configurations here
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Costumer> Costumers { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
    public void AttachAndUpdate<TEntity>(TEntity entity) where TEntity : class
    {
        Attach(entity);

        Entry(entity).State = EntityState.Modified;

        Entry(entity)
            .Properties
            .Where(p => p.CurrentValue == null)
            .ToList()
            .ForEach(p => p.IsModified = false);
    }
}
