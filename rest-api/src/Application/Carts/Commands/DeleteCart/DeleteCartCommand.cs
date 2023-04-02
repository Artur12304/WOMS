using MediatR;
using RestApi.Application.Common.Models;

namespace RestApi.Application.Carts.Commands.DeleteCart;

public record DeleteCartCommand : IRequest<Result>
{
    public int Id { get; set; }
}