using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Carts.Model;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Carts.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCartQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var cart = await _context.Carts.FindAsync(request.Id, cancellationToken);

        if (cart is null)
        {
            throw new NotFoundException($"Cart with Id = {request.Id}, not found.");
        }

        var result = _mapper.Map<CartDto>(cart);

        result.Products = _mapper.Map<List<ProductDto>>(await _context.Products
            .Where(x => cart.ProductIds.Contains(x.Id))
            .ToListAsync(cancellationToken));

        return result;
    }
}
