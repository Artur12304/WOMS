using MediatR;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;
using RestApi.Domain.Enums;

namespace RestApi.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var cart = await _context.Carts.FindAsync(request.CartId, cancellationToken);

        if (cart is null)
        {
            throw new NotFoundException(nameof(Cart), request.CartId);
        }

        var entity = new Order
        {
            ClientId = cart.ClientId,
            ProductIds = cart.ProductIds,
            OrderAmount = cart.CartAmount,
            OrderStatus = OrderStatus.New,
        };

        _context.Orders.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
