using Application.UseCases.User.Commands.Update;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.User.Commands.Delete;

public class DeleteUserHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUserRepository _repository = repository ?? throw new ArgumentNullException();
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.UserId, cancellationToken) ??
            throw new Exception($"User with {request.UserId} was not found. ");

        await _repository.Delete(user, cancellationToken);

        return new DeleteUserResponse(true);
    }
}
