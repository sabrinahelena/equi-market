using Application.UseCases.Producer.Commands.Create;
using Application.UseCases.Producer.Products.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EquiMarket.Controllers;

[Tags("Visão de Produtor")]
[ApiController]
[Route("producer")]
public class ProducerController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(CreateProducerCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProducerCommand command, CancellationToken cancellationToken)
    {
        return Accepted(await _mediator.Send(command, cancellationToken));
    }

    [HttpPost("{producerId}/products")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(CreateProductResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromRoute] int producerId, [FromBody] CreateProductCommand command, CancellationToken cancellationToken)
    {
        command.ProducerId = producerId;
        return Accepted(await _mediator.Send(command, cancellationToken));
    }
}
