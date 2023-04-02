using MediatR;
using RestApi.Application.Orders.Model;

namespace RestApi.Application.Orders.Queries.GetOrder;

public class GetOrderQuery : IRequest<OrderDto>
{
    public int Id { get; set; }
}
