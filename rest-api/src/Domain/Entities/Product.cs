using RestApi.Domain.Common;
using RestApi.Domain.Enums;

namespace RestApi.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public ProductCategory ProductCategory { get; set; }
}
