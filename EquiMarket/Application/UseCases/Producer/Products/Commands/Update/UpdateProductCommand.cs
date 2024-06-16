using Application.DTOs;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.UseCases.Producer.Products.Commands.Update;

public class UpdateProductCommand : ProductDto, IRequest<UpdateProductResponse>
{
    [JsonIgnore]
    public new int ProductId { get; set; }
}
