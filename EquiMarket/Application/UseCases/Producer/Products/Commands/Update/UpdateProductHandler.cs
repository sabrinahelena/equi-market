using Application.UseCases.Producer.Products.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Products.Commands.Update;

public class UpdateProductHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var exists = await _repository.GetById(request.ProductId, cancellationToken)
            ?? throw new Exception($"Product with ProductId: {request.ProductId} was not found to update.");
        
        await _repository.Update(request.Map(), cancellationToken);
        return new UpdateProductResponse(true);
    }
}
