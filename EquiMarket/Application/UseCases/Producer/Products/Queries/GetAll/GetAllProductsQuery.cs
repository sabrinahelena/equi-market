using MediatR;

namespace Application.UseCases.Producer.Products.Queries.GetAll;

public record GetAllProductsQuery() : IRequest<GetAllProductsResponse>;
