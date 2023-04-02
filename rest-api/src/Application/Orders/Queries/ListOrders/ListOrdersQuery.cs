using MediatR;
using RestApi.Application.Orders.Model;

namespace RestApi.Application.Orders.Queries.ListOrders;

public class ListOrdersQuery : IRequest<IEnumerable<OrderDto>> { }
