using MediatR;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Products.Queries.ListProducts;

public class ListProductsQuery : IRequest<IEnumerable<ProductDto>> { }
