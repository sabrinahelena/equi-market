using MediatR;

namespace Application.UseCases.Producer.Products.Commands.Delete;

public record DeleteProductCommand(int Id) : IRequest<DeleteProductResponse>;
