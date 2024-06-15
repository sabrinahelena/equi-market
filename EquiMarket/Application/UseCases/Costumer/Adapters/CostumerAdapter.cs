using Application.UseCases.Costumer.Commands;

namespace Application.UseCases.Costumer.Adapters;

public static class CostumerAdapter
{

    public static Domain.AggregatesModel.CostumerModel.Costumer Map(this CreateCostumerCommand command)
    {
        return new Domain.AggregatesModel.CostumerModel.Costumer
        {
            User = new Domain.AggregatesModel.UserModel.User
            {
                CreatedAt = DateTime.Now,
                BirthDate = command.BirthDate,
                UpdatedAt = DateTime.Now,
                Email = command.Email,
                Password = command.Password,
                Name = command.Name,
                Type = 1
            }
        };
    }
}
