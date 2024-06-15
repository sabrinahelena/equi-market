using Application.UseCases.Costumer.Transactions.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Costumer.Transactions.Commands;

public class CreateTransactionHandler(ITransactionRepository repository) : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
{
    private readonly ITransactionRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactionId = await _repository.Create(request.Map(), cancellationToken);
        return new CreateTransactionResponse(transactionId);
    }
}
