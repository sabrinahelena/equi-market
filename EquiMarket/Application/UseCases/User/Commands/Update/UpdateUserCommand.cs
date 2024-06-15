using Application.DTOs;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.UseCases.User.Commands.Update;

public class UpdateUserCommand : UserDto, IRequest<UpdateUserResponse>
{
    [JsonIgnore]
    public int UserId { get; set; }

    [JsonIgnore]
    public int Type { get; set; }
}
