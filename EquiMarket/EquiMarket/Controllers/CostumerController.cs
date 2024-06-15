using Application.UseCases.Costumer.Commands;
using Application.UseCases.Costumer.Transactions.Commands;
using Application.UseCases.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EquiMarket.Controllers;

[Tags("Visão de Comprador")]
[ApiController]
[Route("costumer")]
public class CostumerController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(CreateCostumerCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCostumerCommand command, CancellationToken cancellationToken)
    {
        return Accepted(await _mediator.Send(command, cancellationToken));
    }

    [HttpPost("{costumerId}/product/{productId}/transactions")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(CreateTransactionCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromRoute] int costumerId, [FromRoute] int productId, [FromBody] CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        command.ProductId = productId;
        command.CostumerId = costumerId;
        return Accepted(await _mediator.Send(command, cancellationToken));
    }
}
