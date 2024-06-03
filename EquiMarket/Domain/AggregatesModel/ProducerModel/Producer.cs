using Domain.AggregatesModel.Common;
using Domain.AggregatesModel.UserModel;

namespace Domain.AggregatesModel.ProducerModel;

public class Producer : Entity
{
    public int UserId { get; init; }
    public virtual User User { get; init; }
    public List<Product> Products { get; init; } = [];
}
