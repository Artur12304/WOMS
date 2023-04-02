using MediatR;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Carts.Commands.UpdateCart;

public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var entity = await _context.Carts.FindAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Cart), request.Id);
        }

        var cartAmount = _context.Products
                .Where(x => request.ProductIds.Contains(x.Id))
                .Sum(x => x.Price);

        entity.ProductIds = request.ProductIds;
        entity.CartAmount = cartAmount;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
