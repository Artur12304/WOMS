using MediatR;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Products.Queries.GetProduct;

public class GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}
