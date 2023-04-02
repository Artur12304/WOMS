using MediatR;

namespace RestApi.Application.Carts.Commands.CreateCart;

public record CreateCartCommand : IRequest<int>
{
    public int ClientId { get; set; }

    public List<int>? ProductIds { get; set; }
}