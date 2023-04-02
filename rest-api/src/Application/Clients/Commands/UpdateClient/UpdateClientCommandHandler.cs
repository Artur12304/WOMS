using MediatR;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var entity = await _context.Clients.FindAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Client), request.Id);
        }

        entity.Name = request.Name;
        entity.Surname = request.Surname;
        entity.Address = request.Address;
        entity.PhoneNumber = request.PhoneNumber;
        entity.Email = request.Email;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
