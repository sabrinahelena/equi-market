using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetAllByProducerId;

public class GetAllProductsByProducerIdQuery : IRequest<GetAllProductsByProducerIdResponse>
{
    public int ProducerId { get; set; }
} 
