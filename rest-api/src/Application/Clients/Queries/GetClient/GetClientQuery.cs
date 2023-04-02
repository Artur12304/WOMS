using MediatR;
using RestApi.Application.Clients.Model;

namespace RestApi.Application.Clients.Queries.GetClient;

public class GetClientQuery : IRequest<ClientDto>
{
    public int Id { get; set; }
}
