using Application.UseCases.Producer.Products.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Products.Commands.Create;

public class CreateProductHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.Create(request.Map(), cancellationToken);
        return new CreateProductResponse(result);
    }
}
