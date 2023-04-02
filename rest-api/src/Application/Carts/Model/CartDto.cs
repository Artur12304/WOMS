using RestApi.Application.Common.Mappings;
using RestApi.Application.Products.Model;
using RestApi.Domain.Entities;

namespace RestApi.Application.Carts.Model;

public class CartDto : IMapFrom<Cart>
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public List<ProductDto> Products { get; set; }

    public decimal CartAmount { get; set; }
}
