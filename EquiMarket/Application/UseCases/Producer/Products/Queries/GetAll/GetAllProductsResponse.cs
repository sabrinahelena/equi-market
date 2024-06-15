using Application.DTOs;

namespace Application.UseCases.Producer.Products.Queries.GetAll;

public record GetAllProductsResponse(List<ProductDto> Products);
