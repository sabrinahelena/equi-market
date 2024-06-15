using MediatR;

namespace Application.UseCases.User.Queries.GetById;

public record GetUserByIdQuery(int UserId, int Type) : IRequest<GetUserByIdResponse>;