using RestApi.Application.Common.Mappings;
using RestApi.Domain.Entities;

namespace RestApi.Application.Clients.Model;

public class ClientDto : IMapFrom<Client>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
