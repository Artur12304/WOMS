using AutoMapper;
using MediatR;
using RestApi.Application.Clients.Model;
using RestApi.Application.Common.Exceptions;
using RestApi.Application.Common.Interfaces;

namespace RestApi.Application.Clients.Queries.GetClient;

public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClientQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var client = await _context.Clients.FindAsync(request.Id, cancellationToken);

        if (client is null)
        {
            throw new NotFoundException($"Client with Id = {request.Id}, not found.");
        }

        var result = _mapper.Map<ClientDto>(client);

        return result;
    }
}
