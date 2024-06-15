using Application.UseCases.Producer.Products.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetAllByProducerId;

public class GetAllProductsByProducerIdHandler(IProductRepository repository) : IRequestHandler<GetAllProductsByProducerIdQuery, GetAllProductsByProducerIdResponse>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<GetAllProductsByProducerIdResponse> Handle(GetAllProductsByProducerIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllByProducerId(request.ProducerId, cancellationToken);
        return new GetAllProductsByProducerIdResponse(result.Select(product => product.Map()).ToList());
    }
}
