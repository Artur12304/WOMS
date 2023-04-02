using MediatR;
using RestApi.Application.Carts.Model;

namespace RestApi.Application.Carts.Queries.ListCarts;

public class ListCartsQuery : IRequest<IEnumerable<CartDto>> { }
