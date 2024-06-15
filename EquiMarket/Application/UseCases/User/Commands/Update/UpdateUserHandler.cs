using Application.UseCases.User.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.User.Commands.Update;

public class UpdateUserHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUserRepository _repository = repository ?? throw new ArgumentNullException();
    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.UserId, cancellationToken) ??
            throw new Exception($"User with {request.UserId} was not found. ");

        await _repository.Update(request.Map(), cancellationToken);

        return new UpdateUserResponse(true);
    }
}
