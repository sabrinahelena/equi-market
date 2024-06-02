using Domain.Common;
using Domain.UserModel;

namespace Domain.ConsumerModel;

public class Costumer : Entity
{
    public int UserId { get; init; }
    public virtual User User { get; init; }
    public virtual List<Review> Reviews { get; init; } = [];
    public virtual List<Transaction> Transactions { get; init; } = [];
}
