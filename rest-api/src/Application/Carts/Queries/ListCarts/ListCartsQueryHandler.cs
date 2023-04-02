using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Carts.Model;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Carts.Queries.ListCarts;

public class ListCartsQueryHandler : IRequestHandler<ListCartsQuery, IEnumerable<CartDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListCartsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartDto>> Handle(ListCartsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var carts = await _context.Carts
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);

        var cartsDto = new List<CartDto>();

        foreach (var cart in carts)
        {
            var cartDto = _mapper.Map<CartDto>(cart);

            cartDto.Products = _mapper.Map<List<ProductDto>>(await _context.Products
                            .Where(x => cart.ProductIds.Contains(x.Id))
                            .ToListAsync(cancellationToken));

            cartsDto.Add(cartDto);
        }

        return cartsDto;
    }
}
