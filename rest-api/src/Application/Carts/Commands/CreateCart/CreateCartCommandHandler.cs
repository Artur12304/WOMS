using MediatR;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Carts.Commands.CreateCart;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var cartAmount = _context.Products
                        .Where(x => request.ProductIds.Contains(x.Id))
                        .Sum(x => x.Price);

        var entity = new Cart
        {
            ClientId = request.ClientId,
            ProductIds = request.ProductIds,
            CartAmount = cartAmount,
        };

        _context.Carts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
