using MediatR;

namespace RestApi.Application.Carts.Commands.UpdateCart;

public record UpdateCartCommand : IRequest<int>
{
    public int Id { get; init; }

    public List<int>? ProductIds { get; set; }
}