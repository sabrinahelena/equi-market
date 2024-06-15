using Application.UseCases.Producer.Commands.Create;
using Application.UseCases.User.Commands.Delete;
using Application.UseCases.User.Commands.Update;
using Application.UseCases.User.Queries.GetById;
using Domain.AggregatesModel.Common;
using Domain.AggregatesModel.CostumerModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EquiMarket.Controllers;

[Tags("Visão geral de Usuário")]
[ApiController]
[Route("user")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("/{userId}/type/{userType}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAndType([FromRoute] int userId, [FromRoute] int userType, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery()
        {
            UserId = userId,
            UserType = userType
        };
        var response = await _mediator.Send(query, cancellationToken);

        if (response.User == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpDelete("/{userId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DeleteUserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int userId, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(userId);

        var response = await _mediator.Send(command, cancellationToken);

        if (!response.Success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("/{userId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UpdateUserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
    {
        command.UserId = userId;
        return Accepted(await _mediator.Send(command, cancellationToken));
    }
}
