using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Products.Commands.Delete;

public class DeleteProductHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id, cancellationToken)
            ?? throw new Exception($"Product with ProductId: {request.Id} was not found to update.");

        await _repository.Delete(product, cancellationToken);

        return new DeleteProductResponse(true);
    }
}
