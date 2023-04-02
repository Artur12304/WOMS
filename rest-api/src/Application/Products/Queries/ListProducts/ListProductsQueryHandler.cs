using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Products.Queries.ListProducts;

public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var products = await _context.Products
                        .AsNoTracking()
                        .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

        return products;
    }
}
