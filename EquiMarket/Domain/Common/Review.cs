using Domain.ConsumerModel;

namespace Domain.Common;

public class Review : Entity
{
    public float Rating { get; init; }
    public string Comment { get; init; }
    public int CostumerId { get; init; }
    public int ProductId { get; init; }

    public virtual Costumer Costumer { get; init; }
    public virtual Product Product { get; init; }
}
