using MediatR;
using RestApi.Application.Carts.Model;

namespace RestApi.Application.Carts.Queries.GetCart;

public class GetCartQuery : IRequest<CartDto>
{
    public int Id { get; set; }
}
