using RestApi.Domain.Common;
using RestApi.Domain.Enums;

namespace RestApi.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public Client Client { get; set; }

    public IEnumerable<Product> Products { get; set; }

    public decimal OrderAmount { get; set; }

    public OrderStatus OrderStatus { get; set; }
}
