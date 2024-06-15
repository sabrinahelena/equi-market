using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetById;

public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
{
    public int ProductId { get; set; }
}