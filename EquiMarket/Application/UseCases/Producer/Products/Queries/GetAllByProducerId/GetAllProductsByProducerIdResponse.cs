using Application.DTOs;

namespace Application.UseCases.Producer.Products.Queries.GetAllByProducerId;

public record GetAllProductsByProducerIdResponse(List<ProductDto> Products);
