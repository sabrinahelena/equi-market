using Application.DTOs;
using Application.UseCases.Producer.Products.Commands.Create;
using Application.UseCases.Producer.Products.Commands.Delete;
using Application.UseCases.Producer.Products.Commands.Update;
using Domain.AggregatesModel.Common;

namespace Application.UseCases.Producer.Products.Adapters;

public static class ProductAdapter
{

    public static Product Map(this CreateProductCommand command)
    {
        return new Product
        {
            Description = command.Description,
            Name = command.Name,
            Materials = command.Materials,
            Origin = command.Origin,
            Price = command.Price,
            ProducerId = command.ProducerId,
            ProductionProcess = command.ProductionProcess,
        };
    }

    public static Product Map(this UpdateProductCommand command)
    {
        return new Product
        {
            Id = command.ProductId,
            Description = command.Description,
            Name = command.Name,
            Materials = command.Materials,
            Origin = command.Origin,
            Price = command.Price,
            ProducerId = command.ProducerId,
            ProductionProcess = command.ProductionProcess,
        };
    }

    public static ProductDto Map(this Product product)
    {
        return new ProductDto
        {
            Description = product.Description,
            Name = product.Name,
            Materials = product.Materials,
            Origin = product.Origin,
            Price = product.Price,
            ProducerId = product.ProducerId,
            ProductionProcess = product.ProductionProcess,
        };
    }

}
