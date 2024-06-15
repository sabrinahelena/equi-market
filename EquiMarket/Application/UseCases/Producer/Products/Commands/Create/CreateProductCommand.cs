using Application.DTOs;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.UseCases.Producer.Products.Commands.Create;

public class CreateProductCommand : ProductDto, IRequest<CreateProductResponse>
{
    [JsonIgnore]
    public new int ProducerId { get; set; }
}
