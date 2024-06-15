using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetAllByProducerId;

public record GetAllProductsByProducerIdQuery(int ProducerId) : IRequest<GetAllProductsByProducerIdResponse>;
