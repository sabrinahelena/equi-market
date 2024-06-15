using MediatR;

namespace Application.UseCases.User.Commands.Delete;

public record DeleteUserCommand(int UserId) : IRequest<DeleteUserResponse>;
