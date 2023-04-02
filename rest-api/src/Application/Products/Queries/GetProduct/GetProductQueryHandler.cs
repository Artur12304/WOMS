using AutoMapper;
using MediatR;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Products.Model;

namespace RestApi.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var product = await _context.Products.FindAsync(request.Id, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException($"Product with Id = {request.Id}, not found.");
        }

        var result = _mapper.Map<ProductDto>(product);

        return result;
    }
}
