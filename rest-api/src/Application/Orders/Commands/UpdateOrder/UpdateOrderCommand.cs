using MediatR;
using RestApi.Domain.Enums;

namespace RestApi.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest<int>
{
    public int Id { get; init; }

    public OrderStatus OrderStatus { get; set; }
}
