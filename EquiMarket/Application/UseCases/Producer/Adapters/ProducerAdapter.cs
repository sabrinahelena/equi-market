using Application.UseCases.Producer.Commands.Create;

namespace Application.UseCases.Producer.Adapters;

public static class ProducerAdapter
{
    public static Domain.AggregatesModel.ProducerModel.Producer Map(this CreateProducerCommand command)
    {
        return new Domain.AggregatesModel.ProducerModel.Producer
        {
            User = new Domain.AggregatesModel.UserModel.User
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                BirthDate = command.BirthDate,
                Email = command.Email,
                Name = command.Name,
                Password = command.Password,
                Type = 2
            }
        };
    }
}
