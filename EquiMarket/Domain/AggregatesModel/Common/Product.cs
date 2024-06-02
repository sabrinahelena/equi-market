using Domain.AggregatesModel.ProducerModel;

namespace Domain.AggregatesModel.Common;

public class Product : Entity
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string Origin { get; init; }
    public string ProductionProcess { get; init; }
    public string Materials { get; init; }
    public double Price { get; init; }
    public int ProducerId { get; init; }
    public virtual Producer Producer { get; init; }
    public virtual List<Review> Reviews { get; init; } = [];
    public virtual Transaction Transaction { get; init; }
}
