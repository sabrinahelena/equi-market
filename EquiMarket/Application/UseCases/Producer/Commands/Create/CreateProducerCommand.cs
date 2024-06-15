using Application.DTOs;
using MediatR;

namespace Application.UseCases.Producer.Commands.Create;

public class CreateProducerCommand : UserDto, IRequest<CreateProducerResponse>
{
}
