using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Orders.Model;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Orders.Queries.ListOrders;

public class ListOrdersByClientQueryHandler : IRequestHandler<ListOrdersByClientQuery,
                                              IEnumerable<OrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListOrdersByClientQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> Handle(ListOrdersByClientQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var orders = await _context.Orders
                        .AsNoTracking()
                        .Where(x => x.ClientId == request.ClientId)
                        .ToListAsync(cancellationToken);

        var ordersDto = new List<OrderDto>();

        foreach (var order in orders)
        {
            var orderDto = _mapper.Map<OrderDto>(order);

            orderDto.Products = _mapper.Map<List<ProductDto>>(await _context.Products
                            .Where(x => order.ProductIds.Contains(x.Id))
                            .ToListAsync(cancellationToken));

            ordersDto.Add(orderDto);
        }

        return ordersDto;
    }
}
