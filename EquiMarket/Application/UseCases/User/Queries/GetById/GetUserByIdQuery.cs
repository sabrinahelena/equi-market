using MediatR;

namespace Application.UseCases.User.Queries.GetById;

public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
{
    public int UserId { get; set; }
    public int UserType { get; set; }
}