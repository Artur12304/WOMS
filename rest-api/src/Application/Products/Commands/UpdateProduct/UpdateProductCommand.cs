using MediatR;
using RestApi.Domain.Enums;

namespace RestApi.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public ProductCategory ProductCategory { get; set; }
}