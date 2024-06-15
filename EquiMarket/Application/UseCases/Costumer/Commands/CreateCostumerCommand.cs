using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.UseCases.Costumer.Commands;

public class CreateCostumerCommand : UserDto, IRequest<CreateCostumerResponse>
{

}
