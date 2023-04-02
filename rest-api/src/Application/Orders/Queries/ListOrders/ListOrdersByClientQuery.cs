using MediatR;
using RestApi.Application.Orders.Model;

namespace RestApi.Application.Orders.Queries.ListOrders;

public class ListOrdersByClientQuery : IRequest<IEnumerable<OrderDto>>
{
    public int ClientId { get; set; }
}
