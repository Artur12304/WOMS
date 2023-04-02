using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Application.Common.Models;
using RestApi.Domain.Entities;

namespace RestApi.Application.Carts.Commands.DeleteCart;

public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public DeleteCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Carts
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Cart), request.Id);
        }

        _context.Carts.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}