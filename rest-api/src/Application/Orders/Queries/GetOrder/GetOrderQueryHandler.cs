using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Orders.Model;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Orders.Queries.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var order = await _context.Orders.FindAsync(request.Id, cancellationToken);

        if (order is null)
        {
            throw new NotFoundException($"Order with Id = {request.Id}, not found.");
        }

        var result = _mapper.Map<OrderDto>(order);

        result.Products = _mapper.Map<List<ProductDto>>(await _context.Products
            .Where(x => order.ProductIds.Contains(x.Id))
            .ToListAsync(cancellationToken));

        return result;
    }
}
