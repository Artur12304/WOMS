using MediatR;
using RestApi.Application.Clients.Model;

namespace RestApi.Application.Clients.Queries.ListClients;

public class ListClientsQuery : IRequest<IEnumerable<ClientDto>> { }
