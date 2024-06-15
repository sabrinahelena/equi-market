using Application.UseCases.User.Adapters;
using Domain.Infraestructure.Repositories;
using MediatR;

namespace Application.UseCases.User.Queries.GetById;

public class GetUserbyIdHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUserRepository _repository = repository ?? throw new ArgumentNullException();

    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAndType(request.UserId, request.Type, cancellationToken);
        return new GetUserByIdResponse(user.Map());
    }
}
