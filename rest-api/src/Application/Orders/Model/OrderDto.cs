using RestApi.Application.Common.Mappings;
using RestApi.Application.Products.Model;
using RestApi.Domain.Entities;
using RestApi.Domain.Enums;

namespace RestApi.Application.Orders.Model;

public class OrderDto : IMapFrom<Order>
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public List<ProductDto> Products { get; set; }

    public decimal OrderAmount { get; set; }

    public OrderStatus OrderStatus { get; set; }
}
