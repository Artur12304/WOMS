using MediatR;
using RestApi.Application.Common.Models;

namespace RestApi.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand : IRequest<Result>
{
    public int Id { get; set; }
}