using MediatR;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var entity = await _context.Orders.FindAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }

        entity.OrderStatus = request.OrderStatus;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
