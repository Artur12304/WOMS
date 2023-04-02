using MediatR;
using RestApi.Domain.Enums;

namespace RestApi.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public ProductCategory ProductCategory { get; set; }
}