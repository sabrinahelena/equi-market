using Domain.ConsumerModel;

namespace Domain.Common;

public class Transaction : Entity
{
    public int CostumerId { get; init; }
    public int ProductId { get; init; }
    public int PaymentStatus { get; init; }
    public int PaymentType { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime FinishedAt { get; init; }

    public virtual Costumer Costumer { get; init; }
    public virtual Product Product { get; init; }
}
