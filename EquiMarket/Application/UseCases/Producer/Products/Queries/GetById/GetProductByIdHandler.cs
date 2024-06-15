using Application.UseCases.Producer.Products.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetById;

public class GetProductByIdHandler(IProductRepository repository) : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id, cancellationToken);
        return new GetProductByIdResponse(result.Map());
    }
}
