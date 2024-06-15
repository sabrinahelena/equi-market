using Application.UseCases.Costumer.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Costumer.Commands;

public class CreateCostumerHandler(ICostumerRepository repository) : IRequestHandler<CreateCostumerCommand, CreateCostumerResponse>
{
    private readonly ICostumerRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<CreateCostumerResponse> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.Create(request.Map(), cancellationToken);
        return new CreateCostumerResponse(result);
    }
}
