using Domain.AggregatesModel.Common;
using Domain.AggregatesModel.UserModel;

namespace Domain.AggregatesModel.CostumerModel;

public class Costumer : Entity
{
    public int UserId { get; init; }
    public virtual User User { get; init; }
    public virtual List<Review> Reviews { get; init; } = [];
    public virtual List<Transaction> Transactions { get; init; } = [];
}
