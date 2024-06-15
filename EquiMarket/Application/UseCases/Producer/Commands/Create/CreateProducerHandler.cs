using Application.UseCases.Producer.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Commands.Create;

public class CreateProducerHandler(IProducerRepository repository) : IRequestHandler<CreateProducerCommand, CreateProducerResponse>
{
    private readonly IProducerRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<CreateProducerResponse> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.Create(request.Map(), cancellationToken);
        return new CreateProducerResponse(result);
    }
}
