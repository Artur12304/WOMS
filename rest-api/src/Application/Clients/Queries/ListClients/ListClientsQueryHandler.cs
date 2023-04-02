using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApi.Application.Clients.Model;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Clients.Queries.ListClients;

public class ListClientsQueryHandler : IRequestHandler<ListClientsQuery, IEnumerable<ClientDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListClientsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDto>> Handle(ListClientsQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var clients = await _context.Clients
                        .AsNoTracking()
                        .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

        return clients;
    }
}
