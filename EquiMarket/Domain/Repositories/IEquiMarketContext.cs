namespace Domain.Repositories;

public interface IEquiMarketContext
{
    void AttachAndUpdate<TEntity>(TEntity entity) where TEntity : class;
}
