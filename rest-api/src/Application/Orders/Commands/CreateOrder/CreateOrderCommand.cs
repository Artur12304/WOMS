using MediatR;

namespace RestApi.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<int>
{
    public int CartId { get; set; }
}
