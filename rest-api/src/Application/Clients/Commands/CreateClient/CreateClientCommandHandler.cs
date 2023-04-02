using MediatR;
using RestApi.Application.Common.Interfaces;
using RestApi.Domain.Entities;

namespace RestApi.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var entity = new Client
        {
            Name = request.Name,
            Surname = request.Surname,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email
        };

        _context.Clients.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}