using RestApi.Application.Common.Mappings;
using RestApi.Domain.Entities;
using RestApi.Domain.Enums;

namespace RestApi.Application.Products.Model;

public class ProductDto : IMapFrom<Product>
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public ProductCategory ProductCategory { get; set; }
}
