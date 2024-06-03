using Domain.AggregatesModel.Common;

namespace Domain.AggregatesModel.UserModel;

public class User : Entity
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public DateTime BirthDate { get; init; }
    public int Type { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
