using Application.UseCases.Producer.Products.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetAll;

public class GetAllProductsHandler(IProductRepository repository) : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll(cancellationToken);
        return new GetAllProductsResponse(result.Select(product => product.Map()).ToList());
    }
}
