using RestApi.Domain.Common;
using RestApi.Domain.Enums;

namespace RestApi.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public int ClientId { get; set; }

    public List<int> ProductIds { get; set; }

    public decimal OrderAmount { get; set; }

    public OrderStatus OrderStatus { get; set; }
}
