using Application.UseCases.Producer.Commands.Create;
using Application.UseCases.Producer.Products.Commands.Create;
using Application.UseCases.Producer.Products.Queries.GetAll;
using Application.UseCases.Producer.Products.Queries.GetAllByProducerId;
using Application.UseCases.Producer.Products.Queries.GetById;
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

    [HttpGet("{producerId}/products")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllProductsByProducerIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductsByProducerId([FromRoute] int producerId, CancellationToken cancellationToken)
    {
        var query = new GetAllProductsByProducerIdQuery { ProducerId = producerId };
        var response = await _mediator.Send(query, cancellationToken);

        if (response.Products == null || !response.Products.Any())
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("/product/{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductByIdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById([FromRoute] int productId, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery { ProductId = productId };
        var response = await _mediator.Send(query, cancellationToken);

        if (response.Product == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("/products")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllProductsResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
    {
        var query = new GetAllProductsQuery();
        var response = await _mediator.Send(query, cancellationToken);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}
