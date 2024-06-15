using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetById;

public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;
