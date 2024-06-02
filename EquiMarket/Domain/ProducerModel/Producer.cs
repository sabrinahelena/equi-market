using Domain.Common;
using Domain.UserModel;

namespace Domain.ProducerModel;

public class Producer : Entity
{
    public int UserId { get; init; }
    public virtual User User { get; init; }
    public List<Product> Products { get; init; } = [];
}
