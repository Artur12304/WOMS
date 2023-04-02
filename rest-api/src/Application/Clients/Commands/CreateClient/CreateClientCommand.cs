using MediatR;

namespace RestApi.Application.Clients.Commands.CreateClient;

public record CreateClientCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}